<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFELineOfManufactureDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFELineOfManufactureDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">

        <div class="content container-fluid">

            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Line of Activity</h4>
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

                                <div class="col-md-12 d-flex ml-2 ">
                                    <div class="col-md-6">

                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Line of Activity*</label>
                                            <div class="col-lg-6">
                                                <asp:DropDownList ID="ddlLineOfActivity" runat="server">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3"></div>
                                        </div>
                                    </div>
                                </div>
                                <h3 class="card-title ml-4">Details Of Manufacture Items: </h3>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. Name of Product *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtManfItemName" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. Annual Manufacturing Capacity (in Tons)</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtManfAnnualCapacity" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3. Approx. Value in Lakhs</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtManfValue" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex justify-content-center">
                                    <center>
                                        <asp:GridView ID="gvManufacture" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                            GridLines="None"
                                            Width="80%" EnableModelValidation="True" Visible="false">
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Name of Product" DataField="CFELA_Manf_ItemName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Annual Manufacturing Capacity (in tonne)" DataField="CFELA_Manf_Item_Quantity" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Appox. value (₹)" DataField="CFELA_Manf_Item_Quantity_In" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            </Columns>
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </center>

                                </div>
                                <div class="col-md-12 d-flex justify-content-center">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label"></label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Button ID="btnAddPromtr" Text="Add Details" class="btn  btn-info btn-lg" runat="server" OnClick="btnAddPromtr_Click" Fore-Color="White" BackColor="YellowGreen" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <h3 class="card-title ml-4 mt-3">Details Of Raw Materials Used in Process:</h3>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. Item *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMaterial" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. Quantity Per*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlPerQuantity" runat="server">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3. Quantity*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtquant" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">4. Quantity In</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlinquantity" runat="server">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>

                                        </div>
                                    </div>

                                </div>

                                <div class="col-md-12 d-flex justify-content-center">
                                    <asp:GridView ID="gvRwaMaterial" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="None"
                                        Width="100%" EnableModelValidation="True" Visible="false">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Name of major raw material" DataField="CFERM_RAW_ITEMNAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="CFERM_RAW_ITEM_QUANTITY" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="CFERM_RAW_ITEM_QUANTITY_IN" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Source(s) of supply" DataField="CFERM_RAW_ITEM_QUANTITY_PER" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                                <div class="col-md-12 d-flex justify-content-center">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label"></label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Button ID="btnadd" Text="Add Details" class="btn  btn-info btn-lg" runat="server" OnClick="btnadd_Click" Fore-Color="White" BackColor="YellowGreen" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex mt-2">
                                    <div class="col-md-4">

                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn  btn-info btn-lg" OnClick="btnPreviuos_Click" />

                                    </div>
                                    <div class="col-md-6 text-right">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-rounded btn-info btn-lg" padding-right="10px" BackColor="Green" OnClick="btnSave_Click" />


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
