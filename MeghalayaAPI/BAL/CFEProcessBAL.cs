﻿using MeghalayaAPI.DAL;
using MeghalayaAPI.Models;
using MeghalayaUIP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeghalayaAPI.BAL
{   
    public class CFEProcessBAL
    {
        public CFEProcessDAL _ObjCFEDAL { get; } = new CFEProcessDAL();

        public string CFEFeasibilityReportInsert(CFE_FEASIBILITY _cfefeasibility)
        {
            return _ObjCFEDAL.CFEFeasibilityReportInsert(_cfefeasibility);
        }


    }
}