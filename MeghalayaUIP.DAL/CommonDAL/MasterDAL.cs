using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MeghalayaUIP.Common;

namespace MeghalayaUIP.DAL.CommonDAL
{
    public class MasterDAL
    {

        string connstr = ConfigurationManager.ConnectionStrings["MIPASS"].ToString();
        public List<MasterCountry> GetCountries()
        {
            List<MasterCountry> lstCountryMstr = new List<MasterCountry>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetCountriesmaster);

                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var Country = new MasterCountry()
                        {
                            CountryId = Convert.ToString(drOptions["MC_ID"]),
                            CountryName = Convert.ToString(drOptions["MC_NAME"])
                        };
                        lstCountryMstr.Add(Country);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstCountryMstr;
        }
        public List<MasterStates> GetStates()
        {
            List<MasterStates> lstStateMstr = new List<MasterStates>();
            SqlDataReader drOptions = null;
            try
            {

                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetStatesmaster);

                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var States = new MasterStates()
                        {

                            StateId = Convert.ToString(drOptions["MS_ID"]),
                            StateName = Convert.ToString(drOptions["MS_NAME"])
                        };
                        lstStateMstr.Add(States);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstStateMstr;
        }
        public List<MasterDistrcits> GetDistrcits()
        {
            List<MasterDistrcits> lstDistrictMstr = new List<MasterDistrcits>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetDistrcitsmaster);

                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var District = new MasterDistrcits()
                        {
                            DistrictId = Convert.ToString(drOptions["DistrictCode"]),
                            DistrictName = Convert.ToString(drOptions["DistrictName"])
                        };
                        lstDistrictMstr.Add(District);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstDistrictMstr;
        }
        public List<MasterMandals> GetMandals(string DistrictId)
        {
            List<MasterMandals> lstMandalMstr = new List<MasterMandals>();
            SqlDataReader drOptions = null;
            try
            {

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@DISTRICT",Convert.ToInt32(DistrictId))
                };
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetMandalsmaster, param);
                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var Mandal = new MasterMandals()
                        {
                            MandalId = Convert.ToString(drOptions["MANDALCODE"]),
                            MandalName = Convert.ToString(drOptions["MANDALNAME"])
                        };
                        lstMandalMstr.Add(Mandal);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstMandalMstr;
        }
        public List<MasterVillages> GetVillages(string MandalId)
        {
            List<MasterVillages> lstVillagesMstr = new List<MasterVillages>();
            SqlDataReader drOptions = null;
            try
            {

                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@MANDALCD",Convert.ToInt32(MandalId))
                };
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetVillagesmaster, param);
                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var Village = new MasterVillages()
                        {
                            VillageId = Convert.ToString(drOptions["villagecode"]),
                            VillageName = Convert.ToString(drOptions["villagename"])
                        };
                        lstVillagesMstr.Add(Village);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstVillagesMstr;
        }
        public List<MasterDepartment> GetDepartment(string ModuleType)
        {
            List<MasterDepartment> lstDeptMstr = new List<MasterDepartment>();
            SqlDataReader drOptions = null;
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@MODULETYPE",Convert.ToInt32(ModuleType))
                };
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetDepartmentmaster, param);

                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var departments = new MasterDepartment()
                        {
                            DepartmentId = Convert.ToString(drOptions["TMD_DEPTID"]),
                            DepartmentName = Convert.ToString(drOptions["TMD_DeptName"])
                        };
                        lstDeptMstr.Add(departments);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstDeptMstr;
        }
        public DataSet GetDepartments()
        {

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(connstr, MasterConstants.GetDeptmaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds;
        }
        public List<MasterSector> GetSectors()
        {
            List<MasterSector> lstSectorMstr = new List<MasterSector>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetSectormaster);
                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var sectors = new MasterSector()
                        {
                            SectorId = Convert.ToString(drOptions["SectorName"]),
                            SectorName = Convert.ToString(drOptions["SectorName"])
                        };
                        lstSectorMstr.Add(sectors);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstSectorMstr;
        }
        public List<MasterLineOfActivity> GetLineOfActivity(string Sector)
        {
            List<MasterLineOfActivity> lstActivityMstr = new List<MasterLineOfActivity>();
            SqlDataReader drOptions = null;
            try
            {
                if (Sector == "")
                    Sector = null;
                SqlParameter[] param = new SqlParameter[]
               {
                    new SqlParameter("@Sector",Sector)
               };
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetLineOfActivitymaster, param);
                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var LineOfActivities = new MasterLineOfActivity()
                        {
                            LOAId = Convert.ToString(drOptions["intLineofActivityid"]),
                            LOAName = Convert.ToString(drOptions["LineofActivity_Name"])
                        };
                        lstActivityMstr.Add(LineOfActivities);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstActivityMstr;
        }
        public string GetPCBCategory(string LineofActivityID)
        {
            string PCBCategory = "";
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@LineofactivityID",Convert.ToInt32(LineofActivityID))
                };
                ds = SqlHelper.ExecuteDataset(connstr, MasterConstants.GetPCBCategory, param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            PCBCategory = Convert.ToString(ds.Tables[0].Rows[0]["PCBcategory"]);

            return PCBCategory;

        }

        public List<MasterConstType> GetConstitutionType()
        {
            List<MasterConstType> lstConstMstr = new List<MasterConstType>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetConstitutionType);

                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var ConstType = new MasterConstType()
                        {
                            ConstId = Convert.ToString(drOptions["CONST_ID"]),
                            ConstName = Convert.ToString(drOptions["CONST_TYPE"])
                        };
                        lstConstMstr.Add(ConstType);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstConstMstr;
        }

        public List<MasterPowerReq> GetPowerKW()
        {
            List<MasterPowerReq> lstPower = new List<MasterPowerReq>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetPowerRequiredRange);

                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var Power = new MasterPowerReq()
                        {
                            PowerReqID = Convert.ToString(drOptions["POWER_ID"]),
                            PowerReqRange = Convert.ToString(drOptions["POWER_KW"])
                        };
                        lstPower.Add(Power);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstPower;
        }

        public List<MasterElecRegulations> GetElectricRegulations()
        {
            List<MasterElecRegulations> lstElecReg = new List<MasterElecRegulations>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetElectricRegulations);

                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var ElecReg = new MasterElecRegulations()
                        {
                            ElRegID = Convert.ToString(drOptions["CEA_RID"]),
                            ElRegNumber = Convert.ToString(drOptions["CEA_RNUMBER"])
                        };
                        lstElecReg.Add(ElecReg);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstElecReg;
        }

        public List<MasterVoltages> GetVoltageMaster()
        {
            List<MasterVoltages> lstvoltg = new List<MasterVoltages>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetVoltageMaster);

                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var Volts = new MasterVoltages()
                        {
                            VoltageID = Convert.ToString(drOptions["VOLTAGEID"]),
                            VoltageValue = Convert.ToString(drOptions["VOLTAGERANGE"])
                        };
                        lstvoltg.Add(Volts);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstvoltg;
        }
        public List<MasterPowerPlants> GetPowerPlantsMaster()
        {
            List<MasterPowerPlants> lstplants = new List<MasterPowerPlants>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetPowerPlantsMaster);

                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var powrplants = new MasterPowerPlants()
                        {
                            PowerPlantID = Convert.ToString(drOptions["POWERPLANTID"]),
                            PowerPlantName = Convert.ToString(drOptions["POWERPLANTNAME"])
                        };
                        lstplants.Add(powrplants);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstplants;
        }

        public List<MasterIndustryType> GetIndustryTypeMaster()
        {
            List<MasterIndustryType> lstplants = new List<MasterIndustryType>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetIndustryTypeMaster);

                if (drOptions != null && drOptions.HasRows)
                {
                    while (drOptions.Read())
                    {
                        var Industry = new MasterIndustryType()
                        {
                            IndustryTypeID = Convert.ToString(drOptions["INDUSTRYTYPEID"]),
                            IndustryType = Convert.ToString(drOptions["INDUSTRYTYPE"])
                        };
                        lstplants.Add(Industry);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstplants;
        }
        public List<MasterCaste> GetCaste()
        {
            List<MasterCaste> lstCasteMstr = new List<MasterCaste>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetCastemaster);
                while (drOptions.Read())
                {
                    var caste = new MasterCaste()
                    {

                        CASTEID = Convert.ToString(drOptions["CASTEID"]),
                        CASTNAME = Convert.ToString(drOptions["CASTNAME"])
                    };
                    lstCasteMstr.Add(caste);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstCasteMstr;
        }
        public List<MasterRegistrationType> GetRegistrationType()
        {
            List<MasterRegistrationType> lstRegistrationTypeMstr = new List<MasterRegistrationType>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetRegistrationType);
                while (drOptions.Read())
                {
                    var ResistrationType = new MasterRegistrationType()
                    {

                        REGISTRATIONTYPEID = Convert.ToString(drOptions["REGISTRATIONTYPEID"]),
                        REGISTRATIONTYPENAME = Convert.ToString(drOptions["REGISTRATIONTYPENAME"])
                    };
                    lstRegistrationTypeMstr.Add(ResistrationType);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstRegistrationTypeMstr;
        }

        public List<MasterSECTORS> GetSector()
        {
            List<MasterSECTORS> lstSECTORMstr = new List<MasterSECTORS>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.Getsector);
                while (drOptions.Read())
                {
                    var Sector = new MasterSECTORS()
                    {
                        SECTORID = Convert.ToString(drOptions["SECTORID"]),
                        SECTORNAME = Convert.ToString(drOptions["SECTORNAME"])
                    };
                    lstSECTORMstr.Add(Sector);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstSECTORMstr;
        }
        public List<MasterENTERPRISETYPE> GetENTERPRISETYPE()
        {
            List<MasterENTERPRISETYPE> lstEnterpriseMstr = new List<MasterENTERPRISETYPE>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetEnterpriseType);
                while (drOptions.Read())
                {
                    var ENTERPRISE = new MasterENTERPRISETYPE()
                    {
                        ENTERPRISETYPECODE = Convert.ToString(drOptions["ENTERPRISETYPECODE"]),
                        ENTERPRISETYPE = Convert.ToString(drOptions["ENTERPRISETYPE"])
                    };
                    lstEnterpriseMstr.Add(ENTERPRISE);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstEnterpriseMstr;
        }

        public List<MasterENERGYLOAD> GetPowerEnergyLoad()
        {
            List<MasterENERGYLOAD> lstENERGYMstr = new List<MasterENERGYLOAD>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetPOWERENERGYLOAD);
                while (drOptions.Read())
                {
                    var ENERGY = new MasterENERGYLOAD()
                    {

                        ENERGYLOAD_ID = Convert.ToString(drOptions["ENERGYLOAD_ID"]),
                        ENERGYLOAD_NAME = Convert.ToString(drOptions["ENERGYLOAD_NAME"])
                    };
                    lstENERGYMstr.Add(ENERGY);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstENERGYMstr;
        }
        public List<MasterVoltage> GetVoltageRange()
        {
            List<MasterVoltage> lstVOLTAGEMstr = new List<MasterVoltage>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetVoltages);
                while (drOptions.Read())
                {
                    var VOLTAGE = new MasterVoltage()
                    {
                        VOLTAGEID = Convert.ToString(drOptions["VOLTAGEID"]),
                        VOLTAGERANGE = Convert.ToString(drOptions["VOLTAGERANGE"])
                    };
                    lstVOLTAGEMstr.Add(VOLTAGE);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstVOLTAGEMstr;
        }
        public string InsertInvestment(InvtentInvest objInvest)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(connstr);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = MasterConstants.InsertInvestment;

                com.Transaction = transaction;
                com.Connection = connection;

                //   com.Parameters.AddWithValue("", Convert.ToInt32(objInvest.CreatedBy));
                com.Parameters.AddWithValue("@CREATEDIP", objInvest.IPAddress);

                com.Parameters.AddWithValue("@COMPANYNAME", objInvest.CompanyName);
                com.Parameters.AddWithValue("@PANNO", objInvest.PAN);
                com.Parameters.AddWithValue("@REGOFCADDRESS", objInvest.Address);

                com.Parameters.AddWithValue("@REGOFCCOUNTRYID", Convert.ToInt32(objInvest.Country));
                com.Parameters.AddWithValue("@REGOFCPINCODE", Convert.ToInt32(objInvest.Pincode));
                com.Parameters.AddWithValue("@REGOFCMOBILE", Convert.ToInt64(objInvest.Phoneno));
                com.Parameters.AddWithValue("@REGOFCEMAIL", objInvest.Emailid);
                com.Parameters.AddWithValue("@REGOFCWEBSITE", objInvest.Website);
                com.Parameters.AddWithValue("@REGOFCFAXNO", objInvest.FaxNo);
                com.Parameters.AddWithValue("@NAME", objInvest.Name);
                com.Parameters.AddWithValue("@DESIGNATION", objInvest.Designation);
                com.Parameters.AddWithValue("@MOBILE", Convert.ToInt64(objInvest.Mobile));
                com.Parameters.AddWithValue("@EMAIL", objInvest.Email);
                com.Parameters.AddWithValue("@PROJECTPROPOSAL", objInvest.ProjectProposal);
                com.Parameters.AddWithValue("@ISMOUSIGNED", objInvest.InvestmentPrevious);
                com.Parameters.AddWithValue("@PROJECTCATEGORY", objInvest.ProjectCategory);
                com.Parameters.AddWithValue("@PROJECTSECTOR", Convert.ToInt32(objInvest.Sector));
                com.Parameters.AddWithValue("@PROJECTINVESTMENT", Convert.ToDecimal(objInvest.Proposed_Investment));
                com.Parameters.AddWithValue("@PROJECTEMPLOYMENT", Convert.ToInt32(objInvest.Proposed_Employment));
                com.Parameters.AddWithValue("@PROJECTLOCATION", objInvest.Project_Location);
                com.Parameters.AddWithValue("@YEAROFCOMMENCEMENT", Convert.ToInt32(objInvest.Expected_Year));
                com.Parameters.AddWithValue("@GOVTSUPPORT", objInvest.Expectationstate_Govt);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
                transaction.Commit();
                connection.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return Result;
        }
        public List<MasterForestDivision> GetForestDivision()
        {
            List<MasterForestDivision> lstForestMstr = new List<MasterForestDivision>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetForestDivision);
                while (drOptions.Read())
                {
                    var Forest = new MasterForestDivision()
                    {

                        FORESTDIV_ID = Convert.ToString(drOptions["FORESTDIV_ID"]),
                        FORESTDIV_NAME = Convert.ToString(drOptions["FORESTDIV_NAME"])
                    };
                    lstForestMstr.Add(Forest);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstForestMstr;
        }

        public List<MasterModule> GetMasterModules()
        {
            List<MasterModule> lstModules = new List<MasterModule>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetModulesMaster);
                while (drOptions.Read())
                {
                    var Modules = new MasterModule()
                    {

                        ModuleID = Convert.ToString(drOptions["MODULEID"]),
                        ModuleName = Convert.ToString(drOptions["MODULENAME"])
                    };
                    lstModules.Add(Modules);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstModules;
        }
        public List<MasterCategoryEst> GetCategoryEST()
        {
            List<MasterCategoryEst> lstCategoryMstr = new List<MasterCategoryEst>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetCategoryEST);
                while (drOptions.Read())
                {
                    var Category = new MasterCategoryEst()
                    {

                        CATEGORYEST_ID = Convert.ToString(drOptions["CATEGORYEST_ID"]),
                        CATEGORYEST_NAME = Convert.ToString(drOptions["CATEGORYEST_NAME"])
                    };
                    lstCategoryMstr.Add(Category);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstCategoryMstr;
        }
        public List<MasterDistricEST> GetDistricEST()
        {
            List<MasterDistricEST> lstDistricESTMstr = new List<MasterDistricEST>();
            SqlDataReader drOptions = null;
            try
            {
                drOptions = SqlHelper.ExecuteReader(connstr, MasterConstants.GetDistricEST);
                while (drOptions.Read())
                {
                    var DISTRICEST = new MasterDistricEST()
                    {

                        DISTRICEST_ID = Convert.ToString(drOptions["DISTRICEST_ID"]),
                        DISTRICEST_NAME = Convert.ToString(drOptions["DISTRICEST_NAME"])
                    };
                    lstDistricESTMstr.Add(DISTRICEST);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (drOptions != null)
                {
                    drOptions.Close();
                }
            }
            return lstDistricESTMstr;
        }
    }
}
