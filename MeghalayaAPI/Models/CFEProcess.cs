using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeghalayaAPI.Models
{
    public class CFEProcess
    {

    }
    public class CFE_FEASIBILITY
    {
        public string QuestionaryId { get; set; }

        public string ApplicationRegNo { get; set; }

        public string NearestConsumerId { get; set; }

        public string Substation { get; set; }

        public string FeederName { get; set; }

        public string Dtc { get; set; }

        public string PoleNumber { get; set; }

        public string Product { get; set; }

        public string ConnectionType { get; set; }

        [Range(0.1, 9999.99, ErrorMessage = "LoadKW must be a valid decimal between 0.1 and 9999.99.")]
        public decimal Loadkw { get; set; }

        public string NoofPremises { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Site Dimension must be a non-negative integer.")]
        public int SiteDimensionSft { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Builtup Area must be a non-negative integer.")]
        public int BuiltupArea { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Number of Floors must be a non-negative integer.")]
        public int NoofFloors { get; set; }

        public string ConnectionPhase { get; set; }

        public string Building { get; set; }

        public string RequestedUgCableSize { get; set; }

        public string RequestedOhCableSize { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        
        [Range(1, int.MaxValue, ErrorMessage = "ServiceType must be a positive integer.")]
        public int ServiceType { get; set; }

        
        [Range(1, int.MaxValue, ErrorMessage = "BillingType must be a positive integer.")]
        public int BillingType { get; set; }

        [Range(0, int.MaxValue)]
        public int AreaType { get; set; }

        public string Remarks { get; set; }

        public string DocumentId { get; set; }

        public string DocumentName { get; set; }

        public string DocumentPath { get; set; }

        public string MeterType { get; set; }

        public string MeteredSide { get; set; }

        [Range(0.1, 9999.99, ErrorMessage = "LoadKVA must be a valid decimal between 0.1 and 9999.99.")]
        public decimal LoadKva { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive integer.")]
        public int UserId { get; set; }

        public string UserIp { get; set; }
        public int Feasible { get; set; }
    }
}