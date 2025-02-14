using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class Sectoralinformation : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindApprovals();
                BindDepartments();
                BindSectors();
                if (Request.QueryString.Count > 0)
                {
                    BindODOP();
                    divproducts.Visible = true;

                }
                BindSectorInformation();
            }
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
        protected void BindSectors()
        {
            try
            {
                ddlSector.Items.Clear();

                List<MasterSector> objSectorModel = new List<MasterSector>();

                objSectorModel = mstrBAL.GetSectors();
                if (objSectorModel != null)
                {
                    ddlSector.DataSource = objSectorModel;
                    ddlSector.DataValueField = "SectorName";
                    ddlSector.DataTextField = "SectorName";
                    ddlSector.DataBind();
                }
                else
                {
                    ddlSector.DataSource = null;
                    ddlSector.DataBind();
                }
                AddSelect(ddlSector);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindApprovals()
        {
            try
            {
                ddlApprovals.Items.Clear();

                List<MasterAPPROVALS> objSectorModel = new List<MasterAPPROVALS>();

                objSectorModel = mstrBAL.GetApprovals();
                if (objSectorModel != null)
                {
                    ddlApprovals.DataSource = objSectorModel;
                    ddlApprovals.DataValueField = "ApprovalID";
                    ddlApprovals.DataTextField = "ApprovalName";
                    ddlApprovals.DataBind();

                }
                else
                {
                    ddlApprovals.DataSource = null;
                    ddlApprovals.DataBind();
                }
                AddSelect(ddlApprovals);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindODOP()
        {
            try
            {
                ddlodop.Items.Clear();

                List<MasterODOP> objODOPModel = new List<MasterODOP>();

                objODOPModel = mstrBAL.GetODOPProduct();
                if (objODOPModel != null)
                {
                    ddlodop.DataSource = objODOPModel;
                    ddlodop.DataValueField = "PRODUCTID";
                    ddlodop.DataTextField = "PRODUCTNAME";
                    ddlodop.DataBind();
                }
                else
                {
                    ddlodop.DataSource = null;
                    ddlodop.DataBind();
                }
                AddSelect(ddlodop);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        protected void BindSectorInformation()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = mstrBAL.GetSectorInformation(ddlApprovals.SelectedValue, ddldept.SelectedValue, ddlSector.SelectedValue, ddlModule.SelectedValue, ddlodop.SelectedValue);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GVSector.DataSource = ds.Tables[0];
                    GVSector.DataBind();
                    if(Request.QueryString.Count == 0)
                    { 
                        GVSector.Columns[5].Visible = false; 
                    }

                }
                else
                {
                    GVSector.DataSource = null;
                    GVSector.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindSectorInformation();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlApprovals_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindSectorInformation();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindSectorInformation();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindSectorInformation();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindSectorInformation();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlodop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindSectorInformation();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}