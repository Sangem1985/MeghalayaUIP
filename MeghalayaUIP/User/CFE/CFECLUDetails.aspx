<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFECLUDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFECLUDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="#">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="#">Pre Establishment</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Change Of Land Use (CLU)</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">Change Of Land Use (CLU) </h3>
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
                                    <asp:HiddenField ID="hdnPreRegUID" runat="server" />

                                    <div class="row">
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">Land Details: </h4>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">District<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDistric" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistric_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Distric" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="Select Mandal" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Village/Town<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                            <asp:ListItem Text="Select Village" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12  d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Extent of Land<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLand" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Type of Ownership<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlownership" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="Individual" Value="1" />
                                                            <asp:ListItem Text="Institutional" Value="2" />
                                                            <asp:ListItem Text="Company" Value="3" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12  d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-2 col-form-label">
                                                        Ownership Proof(upload)<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:CheckBoxList ID="CHKAuthorized" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" Style="padding: 20px" OnSelectedIndexChanged="CHKAuthorized_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="Sale Deed" Value="1" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Patta" Value="2" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Land Holding Certificate" Value="3" style="padding-right: 20px"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h4 class="card-title ml-3">Current and Proposed Land Use: </h4>
                                        <div class="col-md-12  d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Location Lattitude<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLattitude" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Location Longitude<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLongitude" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">                                                    
                                                    <div class="col-lg-6 d-flex">
                                                        <button type="button" onclick="locateFromInputs()">Locate</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Current Land Use<span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:DropDownList ID="ddlCurrentLand" runat="server" class="form-control" OnSelectedIndexChanged="ddlCurrentLand_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="Residential Building" Value="1" />
                                                            <asp:ListItem Text="Residential Apartments" Value="2" />
                                                            <asp:ListItem Text="Institutional buildings" Value="3" />
                                                            <asp:ListItem Text="Commercial Building" Value="4" />
                                                            <asp:ListItem Text="Public and Semi-Public Building" Value="5" />
                                                            <asp:ListItem Text="Assembly Building" Value="6" />
                                                            <asp:ListItem Text="Industrial Building" Value="7" />
                                                            <asp:ListItem Text="Storage Building" Value="8" />
                                                            <asp:ListItem Text="Hazardous Building" Value="9" />
                                                            <asp:ListItem Text="Others" Value="10" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4"></div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Proposed Land Use<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlLandProposed" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="Residential Building" Value="1" />
                                                            <asp:ListItem Text="Residential Apartments" Value="2" />
                                                            <asp:ListItem Text="Institutional buildings" Value="3" />
                                                            <asp:ListItem Text="Commercial Building" Value="4" />
                                                            <asp:ListItem Text="Public and Semi-Public Building" Value="5" />
                                                            <asp:ListItem Text="Assembly Building" Value="6" />
                                                            <asp:ListItem Text="Industrial Building" Value="7" />
                                                            <asp:ListItem Text="Storage Building" Value="8" />
                                                            <asp:ListItem Text="Hazardous Building" Value="9" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="divOther" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Others<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtOther" runat="server" class="form-control" MaxLength="7" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-3" id="lumapInfo" style="flex: 1; padding: 10px; border: 1px solid #ccc; overflow: auto;">
                                                <b>Current Land Use Attributes</b><hr>
                                                <div id="lumapDetails">Click on MAP for features</div>
                                                <asp:HiddenField ID="lblLUMAPAttr" runat="server" ClientIDMode="Static" />
                                            </div>
                                            <div class="col-md-6" style="border: 1px solid #ccc; padding: 0px;">

                                                <div id="map" style="flex: 2; height: 400px;"></div>
                                                <div id="coords" style="padding: 5px; background: #eee;"></div>
                                            </div>


                                            <div class="col-md-3" id="plumapInfo" style="flex: 1; padding: 10px; border: 1px solid #ccc; overflow: auto;">
                                                <b>Proposed Land Use Attributes</b><hr>
                                                <div id="plumapDetails">Click on MAP for features</div>
                                                <asp:HiddenField ID="lblPLUMAPAttr" runat="server" ClientIDMode="Static" />
                                            </div>
                                        </div>


                                        <%--  <div class="col-md-12 d-flex">
                                            <div class="col-md-5" id="LUMap" style="height: 400px;"></div>
                                            <div class="col-md-2"></div>
                                            <div class="col-md-5" id="PLUMap" style="height: 400px;"></div>
                                        </div>--%>

                                        <h4 class="card-title ml-3 mt-3">Document to Upload</h4>

                                        <div class="col-md-12 d-flex" id="divSaleDeed" runat="server" visible="false">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Sale Deed<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupSaledeed" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnSaledeed" OnClick="btnSaledeed_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypSaledeed" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblSaledeed" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex" id="divPatta" runat="server" visible="false">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Patta<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupPatta" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnPatta" OnClick="btnPatta_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypPatta" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblPatta" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex" id="divLand" runat="server" visible="false">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Land Holding Certificate<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupLand" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnLand" OnClick="btnLand_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypLand" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblLand" runat="server" />
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Location Map(Showing access)<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupLocation" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnLocation" OnClick="btnLocation_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypLocation" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblLocation" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Self-Declaration/Affidavit<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupAffidavit" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnAffidavit" OnClick="btnAffidavit_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypAffidavit" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblAffidavit" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">NOCs(if near forest/water bodies)<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupNOC" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnNOC" OnClick="btnNOC_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypNOC" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblNOC" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Longitude and Latitude of the Plot<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupLatitude" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnLatitude" OnClick="btnLatitude_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypLatitude" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblLatitude" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 text-right mb-2">
                                    <asp:HiddenField ID="hfLUFeatures" runat="server" />
                                    <asp:HiddenField ID="hfLUPFeatures" runat="server" />
                                    <asp:HiddenField ID="hfMapData" runat="server" />
                                    <asp:HiddenField ID="hfLumapPanel" runat="server" />
                                    <asp:HiddenField ID="hfPlumapPanel" runat="server" />
                                    <asp:Button Text="Previous" runat="server" ID="btnPrevious" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                    <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
            <asp:PostBackTrigger ControlID="btnLatitude" />
            <asp:PostBackTrigger ControlID="btnNOC" />
            <asp:PostBackTrigger ControlID="btnAffidavit" />
            <asp:PostBackTrigger ControlID="btnLocation" />
            <asp:PostBackTrigger ControlID="btnLand" />
            <asp:PostBackTrigger ControlID="btnPatta" />
            <asp:PostBackTrigger ControlID="btnSaledeed" />
        </Triggers>
    </asp:UpdatePanel>



    <%--------------------- Leaflet.js for map -------------------%>
    <link rel="stylesheet" href="https://unpkg.com/leaflet/dist/leaflet.css" />
    <script src="https://unpkg.com/leaflet/dist/leaflet.js"></script>
    <script src="https://unpkg.com/leaflet-filelayer@1.2.0"></script>
    <script>
        var map, luLayer, pluLayer, marker;

        function initMap() {
            if (map) {
                map.remove(); // Prevent multiple maps on postbacks
            }

            map = L.map('map', { zoomControl: true }).setView([17.385, 78.4867], 8);

            // Show Lat, Lon on mousemove
            map.on('mousemove', function (e) {
                document.getElementById('coords').innerHTML =
                    `Lat: ${e.latlng.lat.toFixed(6)}, Lon: ${e.latlng.lng.toFixed(6)}`;
            });

            // Load both layers
            Promise.all([
                fetch('/Documents/CLU_GEO_DATA/Current_Land_Use.geojson').then(res => res.json()),
                fetch('/Documents/CLU_GEO_DATA/Proposed_Land_Use.geojson').then(res => res.json())
            ]).then(([luData, pluData]) => {
                // Load LUMAP
                luLayer = L.geoJSON(luData, {
                    style: function (feature) {
                        return {
                            color: feature.properties.color || '#00BFFF',
                            weight: 2,
                            fillOpacity: 0.5
                        };
                    }
                }).addTo(map);

                // Load PLUMAP
                pluLayer = L.geoJSON(pluData, {
                    style: function (feature) {
                        return {
                            color: feature.properties.color || '#FF6347',
                            weight: 2,
                            fillOpacity: 0.5
                        };
                    }
                }).addTo(map);

                // Fit map to both bounds
                var bounds = luLayer.getBounds().extend(pluLayer.getBounds());
                map.fitBounds(bounds);
            });

            // On map click — show attributes
            map.on('click', function (e) {
                showAttributes(e.latlng);
            });
        }

        // Show attributes for clicked point
        function showAttributes(latlng) {
            const luDiv = document.getElementById('lumapDetails');
            const pluDiv = document.getElementById('plumapDetails');
            luDiv.innerHTML = '';
            pluDiv.innerHTML = '';

            var luAttr = getAttributesAtPoint(luLayer, latlng);
            var pluAttr = getAttributesAtPoint(pluLayer, latlng);

            luDiv.innerHTML = luAttr || "No Attributes found here";
            pluDiv.innerHTML = pluAttr || "No Attributes found here";

            document.getElementById('lblLUMAPAttr').value =
                (luAttr || "").replace(/<b>/gi, "*").replace(/<[^>]*>/g, "");
            document.getElementById('lblPLUMAPAttr').value =
                (pluAttr || "").replace(/<b>/gi, "*").replace(/<[^>]*>/g, "");
        }

        // Get clicked feature's properties
        function getAttributesAtPoint(layer, latlng) {
            var found = null;
            layer.eachLayer(function (l) {
                if (l.getBounds && l.getBounds().contains(latlng)) {
                    var html = "";
                    for (var key in l.feature.properties) {
                        html += `<b>${key}:</b> ${l.feature.properties[key]}<br>`;
                    }
                    found = html;
                }
            });
            return found;
        }

        // Locate point from textbox inputs
        function locateFromInputs() {
            //var lat = parseFloat(document.getElementById('txtLattitude').value);
            //var lng = parseFloat(document.getElementById('txtLongitude').value);
            var lat = parseFloat(document.getElementById('<%= txtLattitude.ClientID %>').value);
            var lng = parseFloat(document.getElementById('<%= txtLongitude.ClientID %>').value);


            if (!isNaN(lat) && !isNaN(lng)) {
                if (marker) map.removeLayer(marker);
                marker = L.marker([lat, lng]).addTo(map);
                map.setView([lat, lng], 14);

                // Also fetch attributes for this location
                showAttributes(L.latLng(lat, lng));
            } else {
                alert("Please enter valid latitude and longitude.");
            }
        }

        // Run on ASP.NET postback as well
        Sys.Application.add_load(function () {
            initMap();
        });

    </script>
   
    <%--------------------- Leaflet.js for map ------------------%>
</asp:Content>
