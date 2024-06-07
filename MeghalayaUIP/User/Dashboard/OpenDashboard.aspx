<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="OpenDashboard.aspx.cs" Inherits="MeghalayaUIP.User.Dashboard.OpenDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel='stylesheet' href='https://cdn-uicons.flaticon.com/2.4.0/uicons-thin-straight/css/uicons-thin-straight.css'>
    <style>
        .card-body.item {
    background: #f3edfb;
    border-radius: 14px;
}
        .card-body {
            background-color: #fff;
            background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='28' height='49' viewBox='0 0 28 49'%3E%3Cg fill-rule='evenodd'%3E%3Cg id='hexagons' fill='%23f7f7f7' fill-opacity='1' fill-rule='nonzero'%3E%3Cpath d='M13.99 9.25l13 7.5v15l-13 7.5L1 31.75v-15l12.99-7.5zM3 17.9v12.7l10.99 6.34 11-6.35V17.9l-11-6.34L3 17.9zM0 15l12.98-7.5V0h-2v6.35L0 12.69v2.3zm0 18.5L12.98 41v8h-2v-6.85L0 35.81v-2.3zM15 0v7.5L27.99 15H28v-2.31h-.01L17 6.35V0h-2zm0 49v-8l12.99-7.5H28v2.31h-.01L17 42.15V49h-2z'/%3E%3C/g%3E%3C/g%3E%3C/svg%3E");
        }

        .b_rc_gb_sub_title {
            margin-bottom: 4px;
            line-height: 18px;
            font-weight: bold;
            white-space: nowrap;
            text-overflow: ellipsis;
            overflow: hidden;
            color: var(--AC_NeutralFore1);
        }

        _text {
            height: 160px;
            padding: var(--AC_Margin);
            background: var(--AC_ThemeBack2);
        }

        #b_wpt_container .b_wpt_bl {
            margin: var(--wptm-sp);
            display: inline-block;
            overflow: hidden;
            float: left;
            transition-property: opacity, box-shadow;
            transition-duration: .2s;
            border-radius: 16px;
            color: #111;
        }

        #b_wpt_container {
            --wptm-sp: 12px;
            --wptm-hg: 200px;
            box-shadow: none;
            margin-block-end: 40px;
            padding: 0;
            box-sizing: border-box;
            margin-block-start: 20px;
            border-bottom-width: 1px;
            border-bottom-style: solid;
            border-image: linear-gradient(90deg, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, .1) 10%, rgba(0, 0, 0, .1) 90%, rgba(0, 0, 0, 0) 100%) 1;
        }
        .card.item1 {
    *background: #f3edfb;
    border-radius: 16px;
    border: 1px solid #fffafa !important;
    transition-duration: .2s;
}
        .card.item1:hover {
    box-shadow: 0 6.4px 14.4px 0 rgba(0, 0, 0, .13), 0 1.2px 3.6px 0 rgba(0, 0, 0, .1);
    border: 1px solid #ccc;
}
        i.fi.fi-ts-notes {
    font-size: 50px;
}
        h4 a span.badge.rounded-pill.bg-dark.text-sm.p-2:hover {
    color: #00d0f1 !important;
    *border: 1px dotted;
}
        .btn:hover {
    background: linear-gradient(90deg, #2196F3 0, #673AB7 50%, #673AB7 100%);
    box-shadow: 1px 1px 4px 6px #c1c1c1;
    border: 1px solid #fcf;
}
    </style>
    <link href="../assets/admin/css/user.css" rel="stylesheet" />

    <nav aria-label="breadcrumb">
        <ol class="breadcrumb d-flex justify-content-between">
            <li class="breadcrumb-item active" aria-current="page">Dashboard</li>
            <li><a href="#"><span class="badge bg-primary text-white fw-bold">Visit Guidance Site</span></a></li>
        </ol>
    </nav>
    <div class="page-wrapper griddesignmulticount">
        <div class="content container-fluid">
            <div class="card">
                <div class="card-header d-flex justify-content-between">
                    <h3 class="card-title mt-1"><b>Industries Registered with IMA/MIIPP </b></h3>
                    <h4 class="card-title mt-1">
                        <label id="unitname" runat="server"></label>

                    </h4>
                </div>
                <div class="card-body">

                    <div class="d-flex justify-content-between" style="background: #e0e4fd;padding: 10px 8px 2px;border-radius: 4px;margin-bottom: 10px;">

                        <h4 style="display: flex;align-items: center;">Kalyan Babu, Interested in Starting a New Investment? Get Started</h4>
                        <h4><a href="../PreReg/IndustryRegistration.aspx"><span class="badge rounded-pill bg-dark text-sm p-2" style="font-size: 16px;color:#fff;background:#033260 !important;display: flex;
    align-items: center;"><i class="fi fi-tr-bullseye-arrow"></i>&nbsp; New Project</span></a></h4>

                    </div>
                    <div class="card item1" style="width: 13rem;">
                        <div class="card-body item">
                            <h5 class="card-title text-black"><a href="#" style="color:#000;">Future</a></h5>
                            <h6 class="card-subtitle mb-2 text-muted">UNIT ID : 17546577</h6>
                            <p class="card-subtitle mb-2 text-muted">Jun 5, 2024 11:51:15 AM</p>
                            <a href="#" class="card-link" style="color:darkblue">Draft</a>
                            
                        </div>
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header d-flex justify-content-between">
                    <h3 class="card-title mt-1"><b>Your Project Status</b></h3>
                    <h4 class="card-title mt-1">
                        <label id="Label1" runat="server"></label>

                    </h4>
                </div>
                <div class="card-body align-content-center" style="text-align: center;padding-top: 80px;">
                    <i class="fi fi-ts-notes"></i>
                    <p class="align-content-between">You applied Units yet</p>
                   <asp:Button runat="server" ID="btnlistcler" Text="List of Units" OnClick="btnlistcler_Click"  CssClass="mr-3 btn btn-rounded btn-sm btn-approved" Width="120px" />
                    
                    
                    <asp:Button runat="server" ID="Button1" Text="Status of Application" OnClick="Button1_Click" CssClass="btn btn-rounded btn-sm btn-approved" Width="150px" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
