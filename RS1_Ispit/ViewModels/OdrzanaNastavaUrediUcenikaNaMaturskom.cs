using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdrzanaNastavaUrediUcenikaNaMaturskom
    {
        public int MaturskiID { get; set; }
        public int NastavnikID { get; set; }
        public int MaturskiIspitUcenikID { get; set; }
        public string Ucenik { get; set; }
        public double? BrojBodova { get; set; }
    }
}
