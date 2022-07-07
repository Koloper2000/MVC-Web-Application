using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaVrstaUnos
    {

        //atributi
        private string _stringKonekcije;
        private string _nazivTreninga;

        //property
        public string NazivTreninga
        {
            get { return _nazivTreninga; }
            set { _nazivTreninga = value; }
        }

        //konstruktor
        public FormaVrstaUnos(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //public metode
        public bool DaLiJeSvePopunjeno()
        {
            bool svePopunjeno = false;

            if(_nazivTreninga.Length > 0)
            {
                svePopunjeno = true;
            }
            else
            {
                svePopunjeno = false;
            }

            return svePopunjeno;
        }

        public bool DaLiJeJedinstvenZapis()
        {
            bool jedinstvenZapis = false;
            DataSet podaciDataSet = new DataSet();
            VrstaDB vrstaDB = new VrstaDB(_stringKonekcije);
            podaciDataSet = vrstaDB.DajVrstuPoNazivu(_nazivTreninga);

            if(podaciDataSet.Tables[0].Rows.Count == 0)
            {
                jedinstvenZapis = true;
            }
            else
            {
                jedinstvenZapis = false;
            }

            return jedinstvenZapis;
        }


        public bool SnimiPodatke()
        {
            bool uspehSnimanja = false;

            VrstaDB vrstaDB = new VrstaDB(_stringKonekcije);

            Vrsta novaVrsta = new Vrsta();
            novaVrsta.NazivTreninga = _nazivTreninga;
            

            uspehSnimanja = vrstaDB.DodajNovuVrstu(novaVrsta);

            return uspehSnimanja;
        }
    }
}
