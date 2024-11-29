using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class Decriminalisation : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //BindDepartments();
                   // BindSectors();
                    BindDecriminalisation();
                }
            }
            catch (Exception ex)
            { }

        }
        protected void BindDepartments()
        {
            try
            {
                ddldept.Items.Clear();
                List<MasterDepartment> objDepartmentModel = new List<MasterDepartment>();
                objDepartmentModel = mstrBAL.GetDepartment("2");
                if (objDepartmentModel != null)
                {
                    ddldept.DataSource = objDepartmentModel;
                    ddldept.DataValueField = "DepartmentId";
                    ddldept.DataTextField = "DepartmentName";
                    ddldept.DataBind();
                    ddldept.Enabled = true;
                }
                else
                {
                    ddldept.DataSource = null;
                    ddldept.DataBind();
                }
                AddSelect(ddldept);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //for inserting data in ddl directly
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = "All";
                li.Value = "%";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //protected void BindSectors()
        //{
        //    try
        //    {
        //        // Trim the user input from the text field
        //        string sectorInput = txtSector.Text.Trim();

        //        // Fetch all sectors from the database using the existing GetSectors method
        //        List<MasterSector> allSectors = mstrBAL.GetSectors();

        //        // Check if sector input is provided
        //        if (!string.IsNullOrEmpty(sectorInput))
        //        {
        //            // Filter sectors based on the user input using IndexOf with StringComparison.OrdinalIgnoreCase
        //            var filteredSectors = allSectors.Where(s => s.SectorName.IndexOf(sectorInput, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

        //            // Check if any sectors match the user input
        //            if (filteredSectors.Any())
        //            {
        //                // Bind the filtered sectors to the dropdown list
        //                ddldept.DataSource = filteredSectors;
        //                ddldept.DataTextField = "SectorName";  // Assuming SectorName is a property in your sector model
        //                ddldept.DataValueField = "SectorId";  // Assuming SectorId is a property in your sector model
        //                ddldept.DataBind();
        //                ddldept.Enabled = true;
        //            }
        //            else
        //            {
        //                // If no matching sectors are found, disable the dropdown
        //                ddldept.DataSource = null;
        //                ddldept.DataBind();
        //                ddldept.Enabled = false;
        //            }
        //        }
        //        else
        //        {
        //            // If no input is provided, show all sectors
        //            ddldept.DataSource = allSectors;
        //            ddldept.DataTextField = "SectorName";
        //            ddldept.DataValueField = "SectorId";
        //            ddldept.DataBind();
        //            ddldept.Enabled = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle or log the exception
        //        throw ex;
        //    }
        //}


        //if it would be a dropdown
        //protected void BindSectors()
        //{
        //    try
        //    {
        //        ddlSector.Items.Clear();

        //        List<MasterSector> objSectorModel = new List<MasterSector>();

        //        objSectorModel = mstrBAL.GetSectors();
        //        if (objSectorModel != null)
        //        {
        //            ddlSector.DataSource = objSectorModel;
        //            ddlSector.DataValueField = "SectorName";
        //            ddlSector.DataTextField = "SectorName";
        //            ddlSector.DataBind();
        //        }
        //        else
        //        {
        //            ddlSector.DataSource = null;
        //            ddlSector.DataBind();
        //        }
        //        AddSelect(ddlSector);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void BindSectors()
        {
            try
            {
                // Trim the user input from the text field
                string sectorInput = txtSector.Text.Trim();

                // Fetch all sectors from the database using the existing GetSectors method
                List<MasterSector> allSectors = mstrBAL.GetSectors();

                // Check if sector input is provided
                if (!string.IsNullOrEmpty(sectorInput))
                {
                    // Filter sectors based on the user input using IndexOf with StringComparison.OrdinalIgnoreCase
                    var filteredSectors = allSectors.Where(s => s.SectorName.IndexOf(sectorInput, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                    // Check if any sectors match the user input
                    if (filteredSectors.Any())
                    {
                        // Bind the filtered sectors to the dropdown list (or another appropriate control)
                        ddldept.DataSource = filteredSectors;
                        ddldept.DataTextField = "SectorName";  // Assuming SectorName is a property in your sector model
                        ddldept.DataValueField = "SectorId";  // Assuming SectorId is a property in your sector model
                        ddldept.DataBind();
                        ddldept.Enabled = true;
                    }
                    else
                    {
                        // If no matching sectors are found, disable the dropdown
                        ddldept.DataSource = null;
                        ddldept.DataBind();
                        ddldept.Enabled = false;
                    }
                }
                else
                {
                    // If no input is provided, show all sectors
                    ddldept.DataSource = allSectors;
                    ddldept.DataTextField = "SectorName";
                    ddldept.DataValueField = "SectorId";
                    ddldept.DataBind();
                    ddldept.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw ex;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDecriminalisation();
        }
        protected void BindDecriminalisation()
        {
            try
            {
                
                string selectedDeptName = ddldept.SelectedValue;
                string sector = txtSector.Text;
                string selectedDeptId = mstrBAL.GetDeptIdByName(selectedDeptName);

                //if (string.IsNullOrEmpty(selectedDeptId))
                //{
                //    return;
                //}
                DataSet dsInfo = mstrBAL.GetDecriminalisation( selectedDeptId, sector);

                if (dsInfo != null && dsInfo.Tables.Count > 0 && dsInfo.Tables[0].Rows.Count > 0)
                {
                    if (dsInfo.Tables[0].Rows.Count > 0)
                    {
                        ddldept.DataSource = dsInfo.Tables[0];
                        ddldept.DataValueField = "DepartmentId";
                        ddldept.DataTextField = "Department";
                        ddldept.DataBind();
                        ddldept.Enabled = true;
                    }
                    else
                    {
                        ddldept.DataSource = null;
                        ddldept.DataBind();
                    }
                    AddSelect(ddldept);
                    gvDecriminalisation.DataSource = dsInfo.Tables[1];
                    gvDecriminalisation.DataBind();
                }
                else
                {
                    gvDecriminalisation.DataSource = null;
                    gvDecriminalisation.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }



    }
}