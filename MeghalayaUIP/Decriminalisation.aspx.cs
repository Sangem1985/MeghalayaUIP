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

        protected void BindSectors()
        {
            try
            {

                string sectorInput = ddlSector.Text.Trim();

                List<MasterSector> allSectors = mstrBAL.GetSectors();


                if (!string.IsNullOrEmpty(sectorInput))
                {

                    var filteredSectors = allSectors.Where(s => s.SectorName.IndexOf(sectorInput, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                    if (filteredSectors.Any())
                    {
                        ddldept.DataSource = filteredSectors;
                        ddldept.DataTextField = "SectorName";
                        ddldept.DataValueField = "SectorId";
                        ddldept.DataBind();
                        ddldept.Enabled = true;
                    }
                    else
                    {
                        ddldept.DataSource = null;
                        ddldept.DataBind();
                        ddldept.Enabled = false;
                    }
                }
                else
                {
                    ddldept.DataSource = allSectors;
                    ddldept.DataTextField = "SectorName";
                    ddldept.DataValueField = "SectorId";
                    ddldept.DataBind();
                    ddldept.Enabled = true;
                }
            }
            catch (Exception ex)
            {
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

                string selectedDeptId = ddldept.SelectedValue;
                string sector = ddlSector.SelectedValue;
                //string selectedDeptId = mstrBAL.GetDeptIdByName(selectedDeptName);

                //if (string.IsNullOrEmpty(selectedDeptId))
                //{
                //    return;
                //}
                DataSet dsInfo = mstrBAL.GetDecriminalisation(selectedDeptId, sector);

                if (dsInfo != null && dsInfo.Tables.Count > 0 && dsInfo.Tables[0].Rows.Count > 0 || dsInfo.Tables[1].Rows.Count > 0 || dsInfo.Tables[2].Rows.Count > 0)
                {
                    if (dsInfo.Tables[0].Rows.Count > 0 && dsInfo.Tables[1].Rows.Count > 0)
                    {
                        if (!IsPostBack)
                        {
                            ddldept.DataSource = dsInfo.Tables[0];
                            ddldept.DataValueField = "DepartmentID";
                            ddldept.DataTextField = "Department";
                            ddldept.DataBind();
                            ddldept.Enabled = true;
                            ddlSector.DataSource = dsInfo.Tables[1];
                            ddlSector.DataValueField = "SECTOR";
                            ddlSector.DataBind();
                            AddSelect(ddldept);
                            AddSelect(ddlSector);
                        }

                    }
                   
                    else
                    {
                        ddldept.DataSource = null;
                        ddldept.DataBind();
                        ddlSector.DataSource = null;
                        ddlSector.DataBind();
                    }
                    
                    if (dsInfo.Tables[2].Rows.Count > 0)
                    {
                        gvDecriminalisation.DataSource = dsInfo.Tables[2];
                        gvDecriminalisation.DataBind();
                    }
                    else
                    {
                        gvDecriminalisation.DataSource = null;
                        gvDecriminalisation.DataBind();
                    }

                }
                else
                {
                    gvDecriminalisation.DataSource = null;
                    gvDecriminalisation.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*private DataTable GetData()
        {
            DataTable dt = new DataTable();
           
            dt.Columns.Add("Department");
            dt.Columns.Add("Act_Rule_Name");
            dt.Columns.Add("Section_Content");
            dt.Columns.Add("Clause_Section_No");
            dt.Columns.Add("Clause_Description");
            dt.Columns.Add("Trigger_Points");
            dt.Columns.Add("Punishment");
            dt.Columns.Add("Sector");                

            dt.Rows.Add("Finance", "Income Tax Act", "Content 1", "123", "Description 1", "Point A", "Penalty", "Public");
            dt.Rows.Add("Law", "Criminal Code", "Content 2", "456", "Description 2", "Point B", "Fine", "Private");

            return dt; 
        }*/




    }
}