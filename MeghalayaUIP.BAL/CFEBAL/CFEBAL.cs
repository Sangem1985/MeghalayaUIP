using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeghalayaUIP.DAL;
using MeghalayaUIP.Common;
using MeghalayaUIP.DAL.CommonDAL;
using MeghalayaUIP.DAL.CFEDAL;
using System.Data;

namespace MeghalayaUIP.BAL.CFEBLL
{
    public class CFEBAL
    {
        public CFEDAL objCFEDAL { get; } = new CFEDAL();       

        public DataSet GetCFEQuestionnaireDet(string userid)
        {
            return objCFEDAL.GetCFEQuestionnaireDet(userid);
        }
    }
}
