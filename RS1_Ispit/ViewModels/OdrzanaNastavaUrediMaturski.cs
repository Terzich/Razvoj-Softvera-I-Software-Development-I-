using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdrzanaNastavaUrediMaturski
    {
        public int maturskiID { get; set; }
        public int nastavnikID { get; set; }
        public DateTime datum { get; set; }
        public string predmet { get; set; }
        public string napomena { get; set; }

    }
}
