<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEPCBAEDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEPCBAEDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Pre Establishment</a></li>

                    <li class="breadcrumb-item active" aria-current="page">CTE (Pollution Control Board)</li>
                </ol>
            </nav>
            <div class="page-wrapper" id="divText" runat="server">

                <div class="content container-fluid">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">CTE (Pollution Control Board)</h3>
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
                                    <asp:HiddenField ID="hdnQuesID" runat="server" />
                                    <div class="row">


                                        <div>
                                            <h4 class="card-title ml-3 mt-3">Stack Details	 </h4>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1.Stack Attached To D.G Set/Boilers/Furnace/Cupolas/Others  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Stack Height above the roof(In mts)	</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox4" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Temperature('C)	</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4. Expected Quantity		</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox6" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5. Air Pollution Control System		</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox7" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">6. Diameter(In mts)		</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox8" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">7. Flow Rate			</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox9" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">8. Stack Height above Ground Level(In mts)		</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox10" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">9. Stack Top			</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlstack" runat="server" class="form-control">
                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Round/Circular" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Inside Dimension at Top" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Are any Standard of Emission prescribed for or adopted by your Industry?	</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Number of Stack :			</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4 offset-md-4 text-center">
                                                    <asp:Button ID="Button4" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                                </div>
                                            </div>

                                            <%-- <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>
                                        </div>


                                        <h4 class="card-title ml-3 mt-3">Composition of emissions(Nature of Dust)	 </h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Stack Name*	</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlstackname" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Nature of Dust :		</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox11" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. Quantity:		</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox27" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4 offset-md-4 text-center">
                                                <asp:Button ID="Button1" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>

                                        <%--  <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>



                                        <h4 class="card-title ml-3 mt-3">Composition of emissions For Process(Gases)	 </h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Stack Name*	</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Gases:		</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. Quantity:		</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox29" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4 offset-md-4 text-center">
                                                <asp:Button ID="Button3" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>

                                        <%--  <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>


                                        <div>
                                            <h4 class="card-title ml-3 mt-3">Emission from Process & Fugitive Sources	 </h4>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1.Stack Attached To *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox30" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Stack Height above the roof(in mts) *		</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox31" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Temperature('C)	</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox32" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4. Expected Quantity		</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox33" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5.Proposed Air Pollution Control System		</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox34" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">6. Diameter(In mts)		</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox35" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">7. Flow Rate			</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox36" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">8. Stack Height above Ground Level(in mts)		</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox37" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">9. Stack Top			</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Round/Circular" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Inside Dimension at Top" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Are any Standard of Emission prescribed for or adopted by your Industry?	</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Number of Stack :			</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox38" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4 offset-md-4 text-center">
                                                    <asp:Button ID="Button2" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                                </div>
                                            </div>

                                            <%-- <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>
                                        </div>


                                        <h4 class="card-title ml-3 mt-3">Composition of emissions(Emissions from fuel burning)	 </h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Stack Name*	</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList3" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Nature of Dust :			</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox39" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. Quantity:			</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox40" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4 offset-md-4 text-center">
                                                <asp:Button ID="Button7" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>

                                        <%--  <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>



                                        <h4 class="card-title ml-3 mt-3">Composition of emissions of Fuel Burning(Gases)		 </h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Stack Name*	</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList4" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Gases:				</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox41" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. Quantity:			</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox42" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4 offset-md-4 text-center">
                                                <asp:Button ID="Button8" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>

                                        <%--  <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>



                                        <h4 class="card-title ml-3 mt-3">Fuel used Details:	 </h4>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Name of Fuel			</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox14" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2.Daily Consumption		</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox15" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3.Purpose	</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlPurpose" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="D.G. Set" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Boilers" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="thermicfuel heater" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="incinirator" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="5"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.Unit			</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlUnits" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg/day" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kg/month" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Tons/day" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Tons/month" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Kl/day" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Kl/month" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Nos./day" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="Nos./month" Value="8"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4" id="Others" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label"></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtOthers" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4 offset-md-4 text-center">
                                                <asp:Button ID="Button5" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>

                                        <%--  <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>


                                        <div>
                                            <h4 class="card-title ml-3 mt-3">Other sources of pollution </h4>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Is your industry likely to cause noise Pollution :	</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:RadioButtonList ID="rblwater" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Is there odour problem likely to occur from your industry ?:		</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Is there any thermal pollution of surface Waters likely to occur from the industrial Discharge :		</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex" id="Pollution" runat="server" visible="true">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">(If yes, please enclose Supplementary sheet indicating (Please Tick) method proposed for prevention.: </label>
                                                        <div class="col-lg-1 d-flex">
                                                            :
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:FileUpload ID="fupDetailsSolidWaste" runat="server" />
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Button Text="Upload" runat="server" ID="btnDetailsSolidWaste" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:HyperLink ID="hypSWPRTD" runat="server" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex" id="industry" runat="server" visible="true">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">(If yes, please enclose Supplementary sheet indicating (Please Tick) method proposed for prevention.: </label>
                                                        <div class="col-lg-1 d-flex">
                                                            :
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Button Text="Upload" runat="server" ID="Button6" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex" id="industrialDischarge" runat="server" visible="true">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">(If yes, please enclose Supplementary sheet indicating (Please Tick) method proposed for prevention.: </label>
                                                        <div class="col-lg-1 d-flex">
                                                            :
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:FileUpload ID="FileUpload2" runat="server" />
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Button Text="Upload" runat="server" ID="Button9" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h4 class="card-title ml-3 mt-3">Cost of pollution Control </h4>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Total Capital Investment proposed for Pollution monitoring and Control(In lakhs):					</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox20" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">12. Percentage of Capital Investment on Pollution Control to total fixed capital of the unit(In lakhs).:					</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox21" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3.Recurring cost per annum(In lakhs):				</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox22" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>


                                        <div class="col-md-12 text-right mb-3">

                                             <asp:Button ID="btnPrevious" runat="server" Text="Previous" class="btn btn-rounded btn-info btn-lg" Width="150px" OnClick="btnPrevious_Click" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-rounded btn-info btn-lg" Width="150px" OnClick="btnNext_Click" />

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
    </asp:UpdatePanel>


</asp:Content>
