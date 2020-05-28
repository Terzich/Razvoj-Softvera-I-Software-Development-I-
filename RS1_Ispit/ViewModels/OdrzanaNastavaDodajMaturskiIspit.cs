using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdrzanaNastavaDodajMaturskiIspit
    {
        public int SkolaID { get; set; }
        public List<SelectListItem> skole { get; set; }
        public int NastavnikID { get; set; }
        public string Nastavnik { get; set; }
        public int SkolskaGodinaID { get; set; }
        public List<SelectListItem> SkolskaGodina { get; set; }
        public DateTime DatumIspita { get; set; }
        public int PredmetID { get; set; }
        public List<SelectListItem> predmeti { get; set; }
    }
}
