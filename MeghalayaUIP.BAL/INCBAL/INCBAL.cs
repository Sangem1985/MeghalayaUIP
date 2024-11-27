using MeghalayaUIP.DAL.INCDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeghalayaUIP.BAL.INCBAL
{
    public class INCBAL
    {
        public INCDAL IRD { get; } = new INCDAL();


        public DataTable GetFixedCaptial()
        {
            return IRD.GetFixedCaptial();
        }
        public DataTable GetSourceFinance()
        {
            return IRD.GetSourceFinance();
        }
        public DataTable GetEmploymentGeneration()
        {
            return IRD.GetEmploymentGeneration();
        }
    }
}
