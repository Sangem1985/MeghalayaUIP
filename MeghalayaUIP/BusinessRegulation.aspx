<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="BusinessRegulation.aspx.cs" Inherits="MeghalayaUIP.BusinessRegulation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="">

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>

            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                    <li class="breadcrumb-item">Resources</li>
                    <li class="breadcrumb-item active" aria-current="page">BUSINESS REGULATIONS</li>
                </ol>
            </nav>
            <section class="innerpages">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <h4><b>BUSINESS REGULATIONS (ACT/POLICY/RULES/REGULATIONS/ORDERS)</b></h4>
                            <div class="card">
                                <div class="card-body justify-content-center " align="justify">
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

                                        <table cellspacing="0" border="1" width="120%" >
                                            <tr>
                                                <td style="text-align: center; font-size:20px"><b>Draft Regulations</b></td>
                                                <td style="text-align: center; font-size:20px"><b>Final Regulations</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="700px" style="border: solid; vertical-align:top">                                                   
                                                    <asp:GridView ID="grdDraft" runat="server" AutoGenerateColumns="False" CellPadding="4" ShowHeader="true"
                                                        CssClass="GRD table-hover" ForeColor="#333333" Width="100%" ShowFooter="false">
                                                        <RowStyle Height="40px" />
                                                        <HeaderStyle CssClass="GRDHEADER" Font-Bold="True" ForeColor="Black"  />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Act/Policy/Rules/Regulations/Orders" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblAmendment" Text='<%#Eval("AMMENDMENT_NAME") %>' ></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Department Name" HeaderStyle-HorizontalAlign="left">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblDept" Text='<%#Eval("DEPT_NAME") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="left" />
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="View" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="linkDraft" Text="View" OnClick="linkDraft_Click" ></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amndmt ID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAmndmntID" runat="server" Text='<%#Eval("AMMENDMENT_ID") %>'></asp:Label>
                                                                    <itemstyle horizontalalign="Center" width="140px" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amndmt ID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDraftPath" runat="server" Text='<%#Eval("LINK") %>'></asp:Label>
                                                                    <itemstyle horizontalalign="Center" width="140px" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>                                                   
                                                </td>
                                                <td width="700px" style="border: solid; vertical-align:top">                                                  
                                                    <asp:GridView ID="grdFinal" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        ForeColor="#333333" Width="100%" ShowFooter="false" GridLines="Both">
                                                        <RowStyle Height="40px" />
                                                        <HeaderStyle Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Ammendment Name">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblAmendment" Text='<%#Eval("AMMENDMENT_NAME") %>' OnClick="linkDraft_Click"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Department Name">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblDept" Text='<%#Eval("DEPT_NAME") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="View" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="linkFinal" Text="View" OnClick="linkFinal_Click" ></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amndmt ID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAmndmntID" runat="server" Text='<%#Eval("AMMENDMENT_ID") %>'></asp:Label>
                                                                    <itemstyle horizontalalign="Center" width="140px" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amndmt ID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFinalPath" runat="server" Text='<%#Eval("LINK") %>'></asp:Label>
                                                                    <itemstyle horizontalalign="Center" width="140px" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>                                                   
                                                </td>
                                            </tr>
                                        </table>


                                    </div>
                                    <div id="DivFooter" runat="server">
                                        <div>
                                            <div style="font-size: 16px; margin-left: 190px; font-weight: 600; color: black;">
                                                <asp:Label ID="LBLDATETEXT" runat="server" Text="The Data in the Dashboard is updated on a real time basis. Last update:"></asp:Label><asp:Label ID="LBLDATETIME" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
