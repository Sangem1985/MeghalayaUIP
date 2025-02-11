using MeghalayaUIP.BAL.CommonBAL;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeghalayaUIP
{
    public partial class Bestpractices : System.Web.UI.Page
    {
        MasterBAL mstrBAL = new MasterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BINDDEPARTMENT();
                BINDSECTORS();
               BindBestPractice();
            }
        }
        protected void BINDDEPARTMENT()
        {
            try
            {
                ddldepartment.Items.Clear();

                List<MasterDeptBestPractice> objDepartment = new List<MasterDeptBestPractice>();

                objDepartment = mstrBAL.GetDetBestPractice();
                if(objDepartment != null)
                {
                    ddldepartment.DataSource = objDepartment;
                    ddldepartment.DataValueField = "DEPTID";
                    ddldepartment.DataTextField = "DEPARTMENTNAME";
                    ddldepartment.DataBind();
                }
                else
                {
                    ddldepartment.DataSource = null;
                    ddldepartment.DataBind();
                }
                AddSelect(ddldepartment);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        protected void BindSubDepartment(DropDownList ddlsub, string Deptid)
        {
            try
            {


                List<MasterSubDepartment> objSubDept = mstrBAL.GetSubDepartment(Deptid);

                if (objSubDept != null && objSubDept.Count > 0)
                {
                    ddlSubDepartment.DataSource = objSubDept;
                    ddlSubDepartment.DataValueField = "SUB_DEPTID";
                    ddlSubDepartment.DataTextField = "SUB_DEPARTMENTNAME";
                    ddlSubDepartment.DataBind();
                }
                else
                {

                    ddlSubDepartment.DataSource = null;
                    ddlSubDepartment.DataBind();
                }

                AddSelect(ddlSubDepartment);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        protected void BINDSECTORS()
        {
            try
            {
                ddlsector.Items.Clear();

                List<MasterSectors> objSector = new List<MasterSectors>();

                objSector = mstrBAL.GetSectorBestPractice();
                if (objSector != null)
                {
                    ddlsector.DataSource = objSector;
                    ddlsector.DataValueField = "SECTOR_ID";
                    ddlsector.DataTextField = "SECTOR_NAME";
                    ddlsector.DataBind();
                }
                else
                {
                    ddlsector.DataSource = null;
                    ddlsector.DataBind();
                }
                AddSelect(ddlsector);

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
                li.Text = "--Select--";
                li.Value = "%";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                throw ex;
                //lblmsg0.Text = ex.Message;
                //Failure.Visible = true;
                //MGCommonClass.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, hdnUserID.Value);
            }
        }

        protected void ddldepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlSubDepartment.ClearSelection();
                ddlSubDepartment.Items.Clear();
                AddSelect(ddlSubDepartment);
                if (ddldepartment.SelectedItem.Text != "--Select--")
                {
                    BindSubDepartment(ddlSubDepartment, ddldepartment.SelectedValue);                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindBestPractice();
        }
        protected void BindBestPractice()
        {
            try
            {
                string Department = ddldepartment.SelectedValue;
                string Subdept = ddlSubDepartment.SelectedValue;
                string Sector = ddlsector.SelectedValue;

                DataSet dsInfo = mstrBAL.GetDeptBestPractice(Department, Subdept, Sector);

                if (dsInfo != null && dsInfo.Tables.Count > 0 && dsInfo.Tables[0].Rows.Count > 0)
                {
                    if (dsInfo.Tables.Count > 0)
                    {
                        if (dsInfo.Tables[3].Rows.Count > 0)
                        {
                            GvBestPractices.DataSource = dsInfo.Tables[3];
                            GvBestPractices.DataBind();
                        }
                        else
                        {
                            GvBestPractices.DataSource = null;
                            GvBestPractices.DataBind();
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void GvBest_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
            /*  try
              {
                  if (e.Row.RowType == DataControlRowType.DataRow)
                  {
                      string DeptId = GvBest.DataKeys[e.Row.RowIndex].Value.ToString();
                      GridView gvApprovals = e.Row.FindControl("gvApprovals") as GridView;

                      string Department = ddldepartment.SelectedValue;
                      string Subdept = ddlSubDepartment.SelectedValue;
                      string Sector = ddlsector.SelectedValue;

                      DataSet dsInfo = mstrBAL.GetDeptBestPractice(Department, Subdept, Sector);
                      if (dsInfo.Tables.Count > 0)
                      {
                          if (dsInfo.Tables[0].Rows.Count > 0)
                          {
                              gvApprovals.DataSource = dsInfo.Tables[0];
                              gvApprovals.DataBind();
                          }
                      }
                      else
                      {
                          gvApprovals.DataSource = null;
                          gvApprovals.DataBind();
                      }


                  }
              }
              catch (Exception ex)
              {
                  throw ex;
              } */
         
        //}
    }
}