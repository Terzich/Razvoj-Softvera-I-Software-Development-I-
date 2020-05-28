using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdrzanaNastavaUceniciMaturskogIspita
    {
        public int MaturskiID { get; set; }
        public int NastavnikID { get; set; }
        public List<ROW> rows { get; set; }
        public class ROW
        {      
            public int MaturskiUcenikID { get; set; }
            public string Ucenik { get; set; }
            public double Prosjek { get; set; }
            public bool PristupioIspitu { get; set; }
            public double RezultatMaturskog { get; set; }
        }
    }
}
