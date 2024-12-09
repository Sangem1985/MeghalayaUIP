using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.SVRCDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.BAL.SVRCBAL
{
    public class SVRCBAL
    {
        public SVRCDAL SvrcDal = new SVRCDAL();
        public string GETANNUALTURNOVER(string PMAMOUNT, string ANNUALTURNOVER)
        {
            return SvrcDal.GETANNUALTURNOVER(PMAMOUNT, ANNUALTURNOVER);
        }
        public string CFEENTERPRISETYPE(string ANNUALTURNOVER)
        {
            return SvrcDal.CFEENTERPRISETYPE(ANNUALTURNOVER);
        }

        public DataSet GetSvrcApplicantDetails(string userid, string UnitID)
        {
            return SvrcDal.GetSvrcApplicantDetails(userid, UnitID);
        }

        public string InsertRenApplicationDetails(SvrcApplicationDetails objApplicationDetails)
        {
            return SvrcDal.InsertRenApplicationDetails(objApplicationDetails);
        }
        public DataSet BMWEquipment()
        {
            return SvrcDal.BMWEquipment();
        }
    }
}
