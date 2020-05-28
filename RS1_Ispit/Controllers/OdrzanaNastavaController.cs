using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;
using static RS1_Ispit_asp.net_core.ViewModels.OdrzanaNastavaMaturskiIspitiNastavnika;
using static RS1_Ispit_asp.net_core.ViewModels.OdrzanaNastavaUceniciMaturskogIspita;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class OdrzanaNastavaController : Controller
    {
        private MojContext _context;
        public OdrzanaNastavaController(MojContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Nastavnik.Select(n => new OdrzanaNastavaIndex {
                NastanikID = n.Id,
                ImeIPrezimeNastavnika = n.Ime + " " + n.Prezime,
                Skole = "ne z"
            }).ToList();

            return View(model);
        }
        public IActionResult MaturskiIspitiNastavnika(int id)
        {
            var model = new OdrzanaNastavaMaturskiIspitiNastavnika
            {
                NastavnikID = id,
                rows = _context.MaturskiIspit.Where(m => m.NastavnikID == id).Select(m => new Row
                {
                    MaturskiIspitID=m.ID,
                    UceniciKojiNisuPristupili=_context.MaturskiIspitUcenik.Include(mu=>mu.Ucenik).Where(mu=>mu.MaturskiIspitID==m.ID &&
                    mu.PristupioMaturskomIspitu==false).Select(mu=>mu.Ucenik.ImePrezime).ToList(),
                    Datum = m.DatumIspita,
                    Skola = m.Skola.Naziv,
                    Predmet = m.Predmet.Naziv
                }).ToList()
            };

            return View(model);
        }
        public IActionResult DodajMaturskiIspit(int id)
        {
            var imeNastavnika = _context.Nastavnik.Where(n => n.Id == id).Select(n => n.Ime + " " + n.Prezime)
                .FirstOrDefault();
            var model = new OdrzanaNastavaDodajMaturskiIspit
            {
                skole=_context.Skola.Select(s=> new SelectListItem { Value=s.Id.ToString(),Text=s.Naziv}).ToList(),
                NastavnikID=id,
                Nastavnik=imeNastavnika,
                SkolskaGodina=_context.SkolskaGodina.Select(sg=>new SelectListItem { Value=sg.Id.ToString(),Text=sg.Naziv})
                .ToList(),
                predmeti=_context.Predmet.Select(sg => new SelectListItem { Value = sg.Id.ToString(), Text = sg.Naziv })
                .ToList()
            };
            return View(model);
        }
        public IActionResult SnimiMaturski(OdrzanaNastavaDodajMaturskiIspit obj)
        {
            var idN = obj.NastavnikID;
            var noviMaturski = new MaturskiIspit
            {
                SkolaID=obj.SkolaID,
                NastavnikID=obj.NastavnikID,
                SkolskaGodinaID=obj.SkolskaGodinaID,
                DatumIspita=obj.DatumIspita,
                PredmetID=obj.PredmetID
            };
            _context.Add(noviMaturski);
            _context.SaveChanges();
            var ucenici = _context.OdjeljenjeStavka.Where(os => os.Odjeljenje.Razred == 4 && os.Odjeljenje.SkolaID == obj.SkolaID)
                .Select(os => os.UcenikId).Distinct().ToList();
           
            foreach(var u in ucenici)
            {
                if(_context.DodjeljenPredmet.Where(dp=>dp.OdjeljenjeStavka.UcenikId==u).Count(dp=>dp.ZakljucnoKrajGodine<2)==0)
                {
                    int c = 0;
                    var check = _context.MaturskiIspitUcenik.Where(mu => mu.UcenikID == u).ToList();
                    foreach(var ce in check)
                    {
                        if (ce.BrojBodova > 54)
                            c++;
                    }
                    if (c == 0)
                    {
                        _context.Add(new MaturskiIspitUcenik
                        {
                            MaturskiIspitID = noviMaturski.ID,
                            UcenikID = u,
                            PristupioMaturskomIspitu = true,
                            BrojBodova=0
                            
                        });
                        _context.SaveChanges();
                    }
                }
                
            }
            return Redirect("/OdrzanaNastava/MaturskiIspitiNastavnika?id="+idN);
        }
        public IActionResult UrediMaturski(int idM,int idN)
        {
            var model = _context.MaturskiIspit.Where(m => m.ID == idM).Select(m => new OdrzanaNastavaUrediMaturski
            {
                maturskiID=idM,
                nastavnikID=idN,
                datum = m.DatumIspita,
                predmet = m.Predmet.Naziv,
                napomena = m.Napomena
            }).FirstOrDefault();
            return View(model);
        }
        public IActionResult SnimiUredjenMaturski(OdrzanaNastavaUrediMaturski obj)
        {
            var idNa = obj.nastavnikID;
            var maturski = _context.MaturskiIspit.Find(obj.maturskiID);
            maturski.Napomena = obj.napomena;
            _context.SaveChanges();
            return Redirect("/OdrzanaNastava/MaturskiIspitiNastavnika?id=" + idNa);
        }
        public IActionResult UceniciMaturskogIspita(int id,int idN)
        {
            var model = new OdrzanaNastavaUceniciMaturskogIspita
            {
                MaturskiID=id,
                NastavnikID=idN,
                rows=_context.MaturskiIspitUcenik.Where(mu=>mu.MaturskiIspitID==id).Select(mu=>new ROW
                {
                    MaturskiUcenikID=mu.ID,
                    Ucenik=mu.Ucenik.ImePrezime,
                    Prosjek=_context.DodjeljenPredmet.Where(dp=>dp.OdjeljenjeStavka.UcenikId==mu.UcenikID && 
                    dp.OdjeljenjeStavka.Odjeljenje.Razred==4).Average(dp=>dp.ZakljucnoKrajGodine),
                    PristupioIspitu=mu.PristupioMaturskomIspitu,
                    RezultatMaturskog=mu.BrojBodova
                }).ToList()
            };
            return PartialView(model);
        }
        public IActionResult UrediUcenikaNaMaturskom(int id,int IDm,int IDn)
        {
            var model = new OdrzanaNastavaUrediUcenikaNaMaturskom
            {
                MaturskiID=IDm,
                NastavnikID=IDn,
                MaturskiIspitUcenikID = id,
                Ucenik = _context.MaturskiIspitUcenik.Include(mu=>mu.Ucenik).Where(mu => mu.ID == id).FirstOrDefault().Ucenik.ImePrezime,
                BrojBodova = _context.MaturskiIspitUcenik.Where(mu => mu.ID == id).FirstOrDefault().BrojBodova
            };
            return PartialView(model);
        }
        public IActionResult SnimiUredjenogMaturanta(int maturskiID,int maturskiUcenikID,int nastavnikID ,string ucenik, float brojbodova)
        {
            var maturskiStavka = _context.MaturskiIspitUcenik.Where(mu => mu.ID == maturskiUcenikID).FirstOrDefault();
            maturskiStavka.BrojBodova = brojbodova;
            _context.SaveChanges();
            return Redirect("/OdrzanaNastava/UrediMaturski?idM=" + maturskiID+"&idN="+nastavnikID);
        }
        public IActionResult PromijeniPrisustvo(int idMS, int idM, int idN, string pristup)
        {
            var stavka = _context.MaturskiIspitUcenik.Where(mu => mu.ID == idMS).FirstOrDefault();
            if (pristup == "JESTE")
                stavka.PristupioMaturskomIspitu = false;
            else
                stavka.PristupioMaturskomIspitu = true;
            _context.SaveChanges();
            return Redirect("/OdrzanaNastava/UceniciMaturskogIspita?id=" + idM+"&id" +
                "N="+idN);

        }


    }
}