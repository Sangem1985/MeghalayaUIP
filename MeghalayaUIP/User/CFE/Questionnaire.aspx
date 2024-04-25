<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="Questionnaire.aspx.cs" Inherits="MeghalayaUIP.User.CFE.Questionnaire" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">

			<div class="content container-fluid">



				<section class="comp-section">

					<div class="row">
						<div class="col-md-12">
							<div class="card">
								<div class="card-header">
									<h4 class="card-title">Questionnaire - Consent for Establishment</h4>
									<p style="position: absolute;right: 10px;top: 6px;color: red;">*All Fields Are
										Mandatory</p>
								</div>
								<div class="card-body">
									<ul class="nav nav-tabs">
										<li class="nav-item"><a class="nav-link  active" href="#basictab1" data-toggle="tab">1.
												Project Details</a></li>
										<li class="nav-item"><a class="nav-link" href="#basictab2" data-toggle="tab">2.
												Project Financials</a></li>
										<li class="nav-item"><a class="nav-link" href="#basictab3"
												data-toggle="tab">3.
												Project Requirements</a></li>
									</ul>
									<div class="tab-content">
										<div class="tab-pane show active" id="basictab1">
											<div class="card-body">
												<h4 class="card-title">1. Project Details</h4>
												
													<div class="row">
														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-4">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">1. Name of
																		Unit</label>
																	<div class="col-lg-6">
																		<input type="text" class="form-control">
																	</div>
																</div>
															</div>
															<div class="col-md-4">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">2.
																		Constitution of the unit</label>
																	<div class="col-lg-6">
																		<input type="text" class="form-control">
																	</div>
																</div>
															</div>

															<div class="col-md-4">
																<div class="form-group row">
																	<label class="col-lg-9 col-form-label">3. Whether
																		land purchased from MIDCL</label>
																	<div class="col-lg-3 d-flex">
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_male"
																				value="option1" checked="">
																			<label class="form-check-label"
																				for="gender_male">
																				Yes
																			</label>
																		</div>
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_female"
																				value="option2">
																			<label class="form-check-label"
																				for="gender_female">
																				No
																			</label>
																		</div>
																	</div>
																</div>
															</div>
														</div>
														



														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">4. Proposed
																		Location</label>
																	<div class="col-lg-6 d-flex">
																		<select id="7650" class="form-control" attrsearch="" name="7650" tabindex="39" data-displang="E" data-datatype="custLGDHierarchy" data-groupno="50" required="true">
																			<option value="" autocomplete="off"> 
																			Please Select</option>	
																			<option value="740" data-entity-level="null">EASTERN WEST KHASI HILLS</option><option value="273" data-entity-level="null">EAST GARO HILLS</option><option value="657" data-entity-level="null">EAST JAINTIA HILLS</option><option value="274" data-entity-level="null">EAST KHASI HILLS</option><option value="656" data-entity-level="null">NORTH GARO HILLS</option><option value="276" data-entity-level="null">RI BHOI</option><option value="277" data-entity-level="null">SOUTH GARO HILLS</option><option value="663" data-entity-level="null">SOUTH WEST GARO HILLS</option><option value="658" data-entity-level="null">SOUTH WEST KHASI HILLS</option><option value="278" data-entity-level="null">WEST GARO HILLS</option><option value="275" data-entity-level="null">WEST JAINTIA HILLS</option><option value="279" data-entity-level="null">WEST KHASI HILLS</option></select>
																	</div>
																</div>
															</div>
															<div class="col-md-6 d-flex">
																<div class="col-lg-6">
																	<select
																		class="select form-control select2-hidden-accessible"
																		tabindex="-1" aria-hidden="true">
																		<option>Select Mandal</option>
																		<option value="1">-</option>
																		<option value="2">-</option>
																		<option value="3">-</option>
																		<option value="4">-</option>
																	</select>
																</div>
																<div class="col-lg-6">
																	<select
																		class="select form-control select2-hidden-accessible"
																		tabindex="-1" aria-hidden="true">
																		<option>Select Village</option>
																		<option value="1">-</option>
																		<option value="2">-</option>
																		<option value="3">-</option>
																		<option value="4">-</option>
																	</select>
																</div>
															</div>
														</div>


														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-3">
																<div class="form-group row">
																	<label class="col-lg-7 col-form-label">5. Total
																		Extent of Land</label>
																	<div class="col-lg-5 d-flex">
																		<select
																			class="select form-control select2-hidden-accessible"
																			tabindex="-1" aria-hidden="true">
																			<option>Select</option>
																			<option value="1">-</option>
																		<option value="2">-</option>
																		<option value="3">-</option>
																		<option value="4">-</option>
																		</select>
																	</div>
																</div>
															</div>
															<div class="col-md-3">
																<div class="form-group row">
																	<label class="col-lg-4 col-form-label">Acres</label>
																	<div class="col-lg-8">
																		<input type="text" class="form-control">
																	</div>
																</div>
															</div>
															<div class="col-md-3">
																<div class="form-group row">
																	<label
																		class="col-lg-5 col-form-label">Gunthas</label>
																	<div class="col-lg-7">
																		<input type="text" class="form-control">
																	</div>
																</div>
															</div>
															<div class="col-md-3">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">In Square
																		Meters</label>
																	<div class="col-lg-6">
																		<input type="text" class="form-control">
																	</div>
																</div>
															</div>
														</div>

														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">6. Built up
																		Area (Including Parking Cellars)</label>
																	<div class="col-lg-6">
																		<input type="text" class="form-control">

																	</div>
																</div>
															</div>
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">7. Pollution
																		Category of Enterprise</label>
																	<div class="col-lg-6">
																		<input type="text" class="form-control">
																	</div>
																</div>
															</div>
														</div>

														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-4">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">8. Line of
																		Activity</label>
																	<div class="col-lg-6">
																		<input type="text" class="form-control">
																	</div>
																</div>
															</div>
															<div class="col-md-4">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">9. Type of
																		Enterprise</label>
																	<div class="col-lg-6">
																		<input type="text" class="form-control">
																	</div>
																</div>
															</div>
															<div class="col-md-4">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">10. Location
																		of the unit</label>
																	<div class="col-lg-6">
																		<input type="text" class="form-control">
																	</div>
																</div>
																
															</div>
														</div>
													</div>


													<div class="text-right">
														<a href="#basictab2" data-toggle="tab"><button type="submit"
																class="btn btn-rounded btn-info btn-lg">Next</button></a>
													</div>
												
											</div>
										</div>
										<div class="tab-pane" id="basictab2">
											<div class="card-body">
												<h4 class="card-title">2. Project Financials</h4>
												<form action="#">
													<div class="row">
														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-4">
																<div class="form-group row">
																	<label class="col-lg-8 col-form-label">11. Proposed
																		Employment</label>
																	<div class="col-lg-4">
																		<input type="text" class="form-control"
																			value="50">
																	</div>
																</div>
															</div>
															<div class="col-md-4">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">12.
																		Proposal For</label>
																	<div class="col-lg-6">
																		<select
																			class="select form-control select2-hidden-accessible"
																			tabindex="-1" aria-hidden="true">
																			<option>Select</option>
																			<option value="1">New</option>
																			<option value="2">Expansion</option>

																		</select>
																	</div>
																</div>
															</div>
															<div class="col-md-4">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">13.
																		Project Cost</label>
																	<div class="col-lg-6">
																		<select
																			class="select form-control select2-hidden-accessible"
																			tabindex="-1" aria-hidden="true">
																			<option>Select</option>
																			<option value="1">Crores</option>
																			<option value="2">Lakhs</option>
																			<option value="3">Thousands</option>
																			<option value="4">Hundreds</option>
																			<option value="5">Rupes</option>
																		</select>
																	</div>
																</div>
															</div>
														</div>
														
														<div class="table-responsive">
															<table class="table table-bordered mb-0">
																<thead>
																	<tr>

																		<th colspan="2">(Mention Zero in case of leased
																			premises)</th>
																		<th>New Investment</th>

																	</tr>
																</thead>
																<tbody>
																	<tr>
																		<td rowspan="3">a.</td>
																		<td>Value of Land as per saleDeed</td>
																		<td><input type="text" class="form-control"
																				value="0"></td>
																	</tr>
																	<tr>
																		<td>In Rs. Lakhs</td>
																		<td><input type="text" class="form-control"
																				value="0" disabled></td>
																	</tr>
																	<tr>
																		<td>Land Market Value as Per SRO for (14062.37
																			Square Meter)</td>
																		<td><input type="text" class="form-control"
																				value="20000000.00">
																			<button type="button"
																				class="btn btn-warning mt-1"><i
																					class="fa fa-inr"
																					aria-hidden="true"></i> Click Here
																				to Calculate Market Value as Per
																				SRO</button>
																		</td>

																	</tr>

																	<tr>
																		<td rowspan="2">b.</td>
																		<td>Value of Building<span
																				class="text-danger">*</span></td>
																		<td><input type="text" class="form-control"
																				value="0"></td>
																	</tr>
																	<tr>
																		<td>In Rs. Lakhs</td>
																		<td><input type="text" class="form-control"
																				value="0" disabled></td>
																	</tr>

																	<tr>
																		<td rowspan="2">c.</td>
																		<td>Value of Plant & Machinery or Service
																			Equipment<span class="text-danger">*</span>
																		</td>
																		<td><input type="text" class="form-control"
																				value="0"></td>
																	</tr>
																	<tr>
																		<td>In Rs. Lakhs</td>
																		<td><input type="text" class="form-control"
																				value="0" disabled></td>
																	</tr>

																	<tr>
																		<td rowspan="2">d.</td>
																		<td>Expected Annual Turnover<span
																				class="text-danger">*</span></td>
																		<td><input type="text" class="form-control"
																				value="70000000"></td>
																	</tr>
																	<tr>
																		<td>In Rs. Lakhs</td>
																		<td><input type="text" class="form-control"
																				value="700.00000" disabled></td>
																	</tr>
																	<thead>
																		<tr>

																			<th colspan="2">Total Project Cost(in
																				Lakhs)<span class="text-danger">*</span>
																			</th>
																			<th>0</th>

																		</tr>
																	</thead>

																</tbody>
															</table>
														</div>

														<div class="col-md-12 d-flex mt-2" id="padding">
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">Category
																		enterprise</label>
																	<div class="col-lg-3">:</div>
																	<div class="col-lg-3">
																		<h4>Small</h4>
																	</div>
																</div>
															</div>
															<div class="col-md-6">&nbsp;</div>
														</div>

														<div class="col-md-12 d-flex mt-2" id="padding">
															<div class="col-md-6">
																<a href="#basictab1" data-toggle="tab"><button type="submit"
																		class="btn btn-rounded btn-success btn-lg">Previous</button></a>
															</div>
															<div class="col-md-6 text-right">
																<a href="#basictab3" data-toggle="tab"><button type="submit"
																		class="btn btn-rounded btn-info btn-lg">Next</button></a>
															</div>
														</div>

													</div>

												</form>
											</div>
										</div>
										<div class="tab-pane" id="basictab3">
											<div class="card-body">
												<h4 class="card-title">3. Project Requirements</h4>
												<form action="#">
													<div class="row">
														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">14. Power
																		requirement in HP<span
																			class="text-danger">*</span></label>
																	<div class="col-lg-6">
																		<select
																			name="ctl00$ContentPlaceHolder1$ddlPower_Req"
																			id="ctl00_ContentPlaceHolder1_ddlPower_Req"
																			class="form-control txtbox"
																			style="height:33px;width:180px;">
																			<option value="0">--Select--</option>
																			<option value="1">&lt;30 HP</option>
																			<option value="2">&gt;=30 HP and &lt;=100 HP
																			</option>
																			<option value="3">&gt;=101 HP and &lt;=500
																				HP</option>
																			<option selected="selected" value="4">
																				&gt;=501 HP and &lt;=1500 HP</option>
																			<option value="5">&gt;=1501 HP and
																				&lt;=10000 HP</option>
																			<option value="6">&gt;10000 HP</option>

																		</select>

																	</div>
																</div>
															</div>
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-8 col-form-label">15(a). Do you
																		manufacture, store, sale, transport
																		explosives</label>
																	<div class="col-lg-4 d-flex">
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_male"
																				value="option1" checked="">
																			<label class="form-check-label"
																				for="gender_male">
																				Yes
																			</label>
																		</div>
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_female"
																				value="option2">
																			<label class="form-check-label"
																				for="gender_female">
																				No
																			</label>
																		</div>
																	</div>
																</div>
															</div>
														</div>
														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-8 col-form-label">16. Do you
																		have Existing borewell in proposed factory
																		Location</label>
																	<div class="col-lg-4 d-flex">
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_male"
																				value="option1" checked="">
																			<label class="form-check-label"
																				for="gender_male">
																				Yes
																			</label>
																		</div>
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_female"
																				value="option2">
																			<label class="form-check-label"
																				for="gender_female">
																				No
																			</label>
																		</div>
																	</div>
																</div>
															</div>
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-8 col-form-label">15(b). Do you
																		Manufacture, store, sale, Petroleum, Diesel,
																		Kerosene</label>
																	<div class="col-lg-4 d-flex">
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_male"
																				value="option1" checked="">
																			<label class="form-check-label"
																				for="gender_male">
																				Yes
																			</label>
																		</div>
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_female"
																				value="option2">
																			<label class="form-check-label"
																				for="gender_female">
																				No
																			</label>
																		</div>
																	</div>
																</div>
															</div>

														</div>

														<div class="table-responsive mb-3">
															<table
																class="table table table-bordered table-striped mb-0">
																<thead>
																	<tr class="table-primary">
																		<th>Sl. No.</th>
																		<th>Select</th>
																		<th>Water required from</th>
																		<th>Water Required per day( in KLD)</th>
																	</tr>
																</thead>
																<tbody>
																	<tr>
																		<td>1</td>
																		<td><input class="checkbox" type="checkbox"
																				name="checkbox"></td>
																		<td>HMWS & SB</td>
																		<td><input type="text" class="form-control">
																		</td>
																	</tr>
																	<tr>
																		<td>2</td>
																		<td><input class="checkbox" type="checkbox"
																				name="checkbox"></td>
																		<td>Rivers/Canals</td>
																		<td><input type="text" class="form-control">
																		</td>
																	</tr>
																	<tr>
																		<td>3</td>
																		<td><input class="checkbox" type="checkbox"
																				name="checkbox"></td>
																		<td>CDMA</td>
																		<td><input type="text" class="form-control">
																		</td>
																	</tr>
																	<tr>
																		<td>4</td>
																		<td><input class="checkbox" type="checkbox"
																				name="checkbox"></td>
																		<td>Mission Bhagiratha</td>
																		<td><input type="text" class="form-control">
																		</td>
																	</tr>
																</tbody>
															</table>
														</div>

														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-8 col-form-label">17. Generator
																		Requirement</label>
																	<div class="col-lg-4 d-flex">
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_male"
																				value="option1" checked="">
																			<label class="form-check-label"
																				for="gender_male">
																				Yes
																			</label>
																		</div>
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_female"
																				value="option2">
																			<label class="form-check-label"
																				for="gender_female">
																				No
																			</label>
																		</div>
																	</div>
																</div>
															</div>
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">18. Height of
																		the building(in Meters)</label>
																	<div class="col-lg-6">
																		<input type="text" class="form-control"
																			value="17.00">
																	</div>
																</div>
															</div>
														</div>

														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-8 col-form-label">19. Is there
																		any need to Fell trees in Proposed Site</label>
																	<div class="col-lg-4 d-flex">
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_male"
																				value="option1" checked="">
																			<label class="form-check-label"
																				for="gender_male">
																				Yes
																			</label>
																		</div>
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_female"
																				value="option2">
																			<label class="form-check-label"
																				for="gender_female">
																				No
																			</label>
																		</div>
																	</div>
																</div>
															</div>
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">Number of
																		trees to be felled (Girth of tree > 30
																		centimeters)</label>
																	<div class="col-lg-6">
																		<input type="text" class="form-control mt-3"
																			value="44">
																	</div>
																</div>
															</div>
														</div>
														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-12">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">Are there any
																		trees in Non-Exempted (Other than trees in this
																		List )</label>
																	<div class="col-lg-6 d-flex">
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_male"
																				value="option1" checked="">
																			<label class="form-check-label"
																				for="gender_male">
																				Yes
																			</label>
																		</div>
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_female"
																				value="option2">
																			<label class="form-check-label"
																				for="gender_female">
																				No
																			</label>
																		</div>
																	</div>
																</div>
															</div>
														</div>

														<div class="table-responsive mb-3">
															<table class="table table-bordered mb-0">
																<thead>
																	<tr>
																		<th colspan="3" style="margin: 0px !important;padding: 3px 14px !important;">20. Labour Application Type</th>
																	</tr>
																</thead>
																<tbody>
																	<tr>
																		<td rowspan="2">20 a.</td>
																		<td>Does your establishment employ 05 or more contract Labour as defined in the <br/>Contract Labour(Regulation and Abolition)Act, 1970?</td>
																		<td>
																			<div class="form-check form-check-inline">
																				<input class="form-check-input" type="radio"
																					name="gender" id="gender_male"
																					value="option1" checked="">
																				<label class="form-check-label"
																					for="gender_male">
																					Yes
																				</label>
																			</div>
																			<div class="form-check form-check-inline">
																				<input class="form-check-input" type="radio"
																					name="gender" id="gender_female"
																					value="option2">
																				<label class="form-check-label"
																					for="gender_female">
																					No
																				</label>
																			</div>
																		</td>
																	</tr>
																	<tr>
																		<td>No of Workers</td>
																		<td><input type="text" class="form-control" value="22"></td>
																	</tr>

																	<tr>
																		<td rowspan="2">20 b.</td>
																		<td>Does your establishment employ 05 or more Inter-State migrant workmen as defined<br/> in the Inter-state Migrant Workmen Act, 1979?</td>
																		<td>
																			<div class="form-check form-check-inline">
																				<input class="form-check-input" type="radio"
																					name="gender" id="gender_male"
																					value="option1" checked="">
																				<label class="form-check-label"
																					for="gender_male">
																					Yes
																				</label>
																			</div>
																			<div class="form-check form-check-inline">
																				<input class="form-check-input" type="radio"
																					name="gender" id="gender_female"
																					value="option2">
																				<label class="form-check-label"
																					for="gender_female">
																					No
																				</label>
																			</div>
																		</td>
																	</tr>
																	<tr>
																		<td>No of Workers</td>
																		<td><input type="text" class="form-control" value="22"></td>
																	</tr>

																	<tr>
																		<td rowspan="3">20 c.</td>
																		<td>Does your establishment fall under the definition of establishment as per Building<br/> and Other Constrution Worker(RE&COS) Act, 1996?</td>
																		<td>
																			<div class="form-check form-check-inline">
																				<input class="form-check-input" type="radio"
																					name="gender" id="gender_male"
																					value="option1" checked="">
																				<label class="form-check-label"
																					for="gender_male">
																					Yes
																				</label>
																			</div>
																			<div class="form-check form-check-inline">
																				<input class="form-check-input" type="radio"
																					name="gender" id="gender_female"
																					value="option2">
																				<label class="form-check-label"
																					for="gender_female">
																					No
																				</label>
																			</div>
																		</td>
																	</tr>
																	<tr>
																		
																		<td>Whether your establishment has employed or had employed on any day of the preceding <br/>12 months, 10 or more building workers in any “Building & Other Construction Works”</td>
																		<td>
																			<div class="form-check form-check-inline">
																				<input class="form-check-input" type="radio"
																					name="gender" id="gender_male"
																					value="option1" checked="">
																				<label class="form-check-label"
																					for="gender_male">
																					Yes
																				</label>
																			</div>
																			<div class="form-check form-check-inline">
																				<input class="form-check-input" type="radio"
																					name="gender" id="gender_female"
																					value="option2">
																				<label class="form-check-label"
																					for="gender_female">
																					No
																				</label>
																			</div>
																		</td>
																	</tr>
																	<tr>
																		<td>No of Workers</td>
																		<td><input type="text" class="form-control" value="22"></td>
																	</tr>

																	<tr>
																		<td rowspan="2">20 d.</td>
																		<td>Does your establishment provide 05 or more inter-state migrant workmen on contractual basis as <br/>defined in the Inter-state Migrant Workmen Act, 1979?(for Contractor)</td>
																		<td>
																			<div class="form-check form-check-inline">
																				<input class="form-check-input" type="radio"
																					name="gender" id="gender_male"
																					value="option1" checked="">
																				<label class="form-check-label"
																					for="gender_male">
																					Yes
																				</label>
																			</div>
																			<div class="form-check form-check-inline">
																				<input class="form-check-input" type="radio"
																					name="gender" id="gender_female"
																					value="option2">
																				<label class="form-check-label"
																					for="gender_female">
																					No
																				</label>
																			</div>
																		</td>
																	</tr>
																	<tr>
																		<td>No of Workers</td>
																		<td><input type="text" class="form-control" value="22"></td>
																	</tr>

																	<tr>
																		<td rowspan="1">20 e.</td>
																		<td>Does your establishment employ 05 or more contract labour(License for contractors) as defined <br/>in the contract labour(Regulation and Abolition) act, 1970?</td>
																		<td>
																			<div class="form-check form-check-inline">
																				<input class="form-check-input" type="radio"
																					name="gender" id="gender_male"
																					value="option1" checked="">
																				<label class="form-check-label"
																					for="gender_male">
																					Yes
																				</label>
																			</div>
																			<div class="form-check form-check-inline">
																				<input class="form-check-input" type="radio"
																					name="gender" id="gender_female"
																					value="option2">
																				<label class="form-check-label"
																					for="gender_female">
																					No
																				</label>
																			</div>
																		</td>
																	</tr>
																	
																	
																	</tbody>
																	
																	
																
															</table>
														</div>


														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-8 col-form-label">21. Does the unit Location fall within 100mts vicinity of any water body?</label>
																	<div class="col-lg-4 d-flex">
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_male"
																				value="option1" checked="">
																			<label class="form-check-label"
																				for="gender_male">
																				Yes
																			</label>
																		</div>
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_female"
																				value="option2">
																			<label class="form-check-label"
																				for="gender_female">
																				No
																			</label>
																		</div>
																	</div>
																</div>
															</div>
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-8 col-form-label">22. Do you require approval from Commerical Tax</label>
																	<div class="col-lg-4 d-flex">
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_male"
																				value="option1" checked="">
																			<label class="form-check-label"
																				for="gender_male">
																				Yes
																			</label>
																		</div>
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_female"
																				value="option2">
																			<label class="form-check-label"
																				for="gender_female">
																				No
																			</label>
																		</div>
																	</div>
																</div>
															</div>

														</div>

														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-8 col-form-label">23. DO you Use (High Tension)HT meter Above 70KVA<span class="text-danger">*</span></label>
																	<div class="col-lg-4 d-flex">
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_male"
																				value="option1" checked="">
																			<label class="form-check-label"
																				for="gender_male">
																				Yes
																			</label>
																		</div>
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_female"
																				value="option2">
																			<label class="form-check-label"
																				for="gender_female">
																				No
																			</label>
																		</div>
																	</div>
																</div>
															</div>
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">Regulation</label>
																	<div class="col-lg-6">

																		<select name="ctl00$ContentPlaceHolder1$ddlregulation" onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder1$ddlregulation\',\'\')', 0)" id="ctl00_ContentPlaceHolder1_ddlregulation" tabindex="1" class="form-control txtbox" style="height:33px;width:180px;">
																			<option value="--Select--">--Select--</option>
																			<option selected="selected" value="1">43(3)</option>
																			<option value="3">32</option>
																	
																		</select>
<p>43(3)- Electrical Installation/ 32 - Generating Unit/Generators</p>
																	</div>
																</div>
															</div>

														</div>

														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-8 col-form-label">Voltage</label>
																	<div class="col-lg-4 d-flex">
																		<select name="ctl00$ContentPlaceHolder1$ddlvoltage" onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder1$ddlvoltage\',\'\')', 0)" id="ctl00_ContentPlaceHolder1_ddlvoltage" tabindex="1" class="form-control txtbox" style="height:33px;width:180px;">
																			<option value="--Select--">--Select--</option>
																			<option selected="selected" value="1">11 KV</option>
																			<option value="2">33 KV</option>
																			<option value="3">132 KV</option>
																			<option value="4">Exceeding 220 KV</option>
																			<option value="5">220 KV</option>
																			<option value="6">140 KV</option>
																	
																		</select>
																		
																	</div>
																</div>
															</div>
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-6 col-form-label">Aggregate Capacity</label>
																	<div class="col-lg-6">

																		<input type="text" class="form-control" value="550">

																	</div>
																</div>
															</div>

														</div>

														<div class="col-md-12 d-flex" id="padding">
															<div class="col-md-6">
																<div class="form-group row">
																	<label class="col-lg-8 col-form-label">24. Do you store RS, DS</label>
																	<div class="col-lg-4 d-flex">
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_male"
																				value="option1" checked="">
																			<label class="form-check-label"
																				for="gender_male">
																				Yes
																			</label>
																		</div>
																		<div class="form-check form-check-inline">
																			<input class="form-check-input" type="radio"
																				name="gender" id="gender_female"
																				value="option2">
																			<label class="form-check-label"
																				for="gender_female">
																				No
																			</label>
																		</div>
																	</div>
																</div>
															</div>
															<div class="col-md-6">
																&nbsp;
															</div>

														</div>


														<div class="col-md-12 d-flex text-center" id="padding">
															<div class="col-md-4">
																<a href="#basictab2"> <button type="submit" class="btn btn-rounded btn-success1 btn-lg"><span class="spinner-border spinner-border-sm mr-2 mb-1" role="status"></span> Show Approvals Required</button></a>
															</div>
															<div class="col-md-4">
																<a href="#basictab2"><button type="submit" class="btn btn-rounded btn-success1 btn-lg"><span class="spinner-border spinner-border-sm mr-2 mb-1" role="status"></span> Submit Questionnaire</button></a>
															</div>
															<div class="col-md-4">
																<a href="#basictab2"><button type="submit" class="btn btn-rounded btn-success2 btn-lg">Show Enclousers List</button></a>
															</div>
															
															
														</div>

														<div class="col-md-12 d-flex mt-4" id="padding">
															<div class="col-md-6">
																<a href="#basictab2" data-toggle="tab"><button type="submit"
																		class="btn btn-rounded btn-success btn-lg">Previous</button></a>
															</div>
															
														</div>
														
													</div>


													
												</form>
												
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>


					<div class="row">
						<div class="col-lg-12">
							<div class="card">
								<div class="card-header">
									<h4 class="card-title">Fee Details(in Rs.)</h4>
								</div>
								<div class="card-body">
									<div class="table-responsive">
										<table class="table table-hover table-bordered mb-0">
											<thead>
												<tr>
													<th>S No</th>
													<th>Approval Required</th>
													<th>Department</th>
													<th>Fees (Rs.)</th>
												</tr>
											</thead>
											<tbody>
												<tr>
													<td>1</td>
													<td>SERVICE CONNECTION CERTIFICATE FROM TSNPDCL</td>
													<td>TSNPDCL</td>
													<td>0</td>
												</tr>
												<tr>
													<td>2</td>
													<td>PERMISSION FROM GROUND WATER DEPARTMENT TO DIG BORE WELL</td>
													<td>GROUND WATER</td>
													<td>14,500</td>
												</tr>
												<tr>
													<td>3</td>
													<td>PROVISIONAL NOC FROM FIRE SERVICES DEPARTMENT</td>
													<td>FIRE</td>
													<td>50,000</td>
												</tr>
											</tbody>
										</table>
									</div>
								</div>
							</div>
						</div>

					</div>
				</section>




			</div>
		</div>
</asp:Content>
