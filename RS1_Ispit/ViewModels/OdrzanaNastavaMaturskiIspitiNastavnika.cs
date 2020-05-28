using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdrzanaNastavaMaturskiIspitiNastavnika
    {
        public int NastavnikID { get; set; }
        public List<Row> rows { get; set; }
        public class Row
        {
            public int MaturskiIspitID { get; set; }
            public List<string> UceniciKojiNisuPristupili { get; set; }
            public DateTime Datum { get; set; }
            public string Skola { get; set; }
            public string Predmet { get; set; }
        }
        
    }
}
