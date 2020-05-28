using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class MaturskiIspitUcenik
    {
        public int ID { get; set; }
       
        [ForeignKey(nameof(MaturskiIspitID))]
        public virtual MaturskiIspit MaturskiIspit { get; set; }
        public int MaturskiIspitID { get; set; }
        
        [ForeignKey(nameof(UcenikID))]
        public virtual Ucenik Ucenik { get; set; }
        public int UcenikID { get; set; }
        public bool PristupioMaturskomIspitu { get; set; }
        public double BrojBodova { get; set; }
    }
}
