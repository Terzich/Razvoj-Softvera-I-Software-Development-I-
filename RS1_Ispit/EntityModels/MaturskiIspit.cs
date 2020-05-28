using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class MaturskiIspit
    {
        public int ID { get; set; }

        [ForeignKey(nameof(SkolaID))]
        public virtual Skola Skola { get; set; }
        public int SkolaID { get; set; }
        
        [ForeignKey(nameof(NastavnikID))]
        public virtual Nastavnik Nastavnik { get; set; }
        public int NastavnikID { get; set; }

        [ForeignKey(nameof(SkolskaGodinaID))]
        public virtual SkolskaGodina SkolskaGodina { get; set; }
        public int SkolskaGodinaID { get; set; }
        public DateTime DatumIspita { get; set; }

        [ForeignKey(nameof(PredmetID))]
        public virtual Predmet Predmet { get; set; }
        public int PredmetID { get; set; }
        public string Napomena { get; set; }
    }
}
