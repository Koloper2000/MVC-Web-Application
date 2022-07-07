using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PoslovnaLogika
{
    public class PoslovnaPravila
    {
        //atributi
        private string _stringKonekcije;

        //property
        public string StringKonekcije
        {
            get { return _stringKonekcije; }
        }

        //konstruktor
        public PoslovnaPravila(string noviStringkonekcije)
        {
            _stringKonekcije = noviStringkonekcije;
        }

        //public metode

        //Ova metoda brise plan i sve planove iz baze
        //nakon isteka roka od 7 dana od dana izdavanja plana 
        public bool ObrisiPlanNakonIstekaRokaPerioda()
        {
            PlanDB plan = new PlanDB(_stringKonekcije);
            bool uspeh = false;
            uspeh = plan.ObrisiPlanNakonIstekaRoka();
            return uspeh;
        }


    }
}
