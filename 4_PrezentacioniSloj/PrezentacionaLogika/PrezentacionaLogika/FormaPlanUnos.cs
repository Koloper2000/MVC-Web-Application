using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KlasePodataka;
using PoslovnaLogika;

namespace PrezentacionaLogika
{
    public class FormaPlanUnos
    {
        //atributi
        private string _stringKonekcije;
        private string _datum;
        private string _vreme;
        private string _opis;
        private string _nazivTreninga;
        private Plan _plan = new Plan();
        

        public string Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }

        public string Vreme
        {
            get { return _vreme; }
            set { _vreme = value; }
        }

        public string Opis
        {
            get { return _opis; }
            set { _opis = value; }
        }

        public string NazivTreninga
        {
            get { return _nazivTreninga; }
            set { _nazivTreninga = value; }
        }

        //konstruktor
        public FormaPlanUnos(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //javne metode
        public DataSet DajVrsteZaCombo()
        {
            DataSet podaciDataSet = new DataSet();
            VrstaDB vrstaDB = new VrstaDB(_stringKonekcije);
            podaciDataSet = vrstaDB.DajSveVrste();

            return podaciDataSet;
        }


        public DataSet DajPodatkeZaComboTermini()
        {
            DataSet podaciDataSet = new DataSet();

            WSPlanTreninga.Service1 servis = new WSPlanTreninga.Service1();
            podaciDataSet = servis.DajSveTermine();

            return podaciDataSet;
        }

        public bool DaLiJeSvePopunjeno()
        {
            bool svePopunjeno = false;

            if(_nazivTreninga.Length > 0 && _datum.Length > 0 /*&&  _vreme.Length > 0*/ && _opis.Length > 0)
            {
                if(_nazivTreninga.Equals("Izaberite...") /*|| _vreme.Equals("Izaberite...")*/)
                {
                    svePopunjeno = false;
                }
                else
                {
                    svePopunjeno = true;
                }
                
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
            PlanDB planDB = new PlanDB(_stringKonekcije);
            _plan.IdVrste = planDB.DajIdPremaNazivuTreninga(_nazivTreninga);
            
            _plan.Datum = _datum;
            _plan.Vreme = _vreme;
            _plan.Opis = _opis;
            podaciDataSet = planDB.DajPlanPremaDatumuIVremenu(_plan);

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

            PlanDB planDB = new PlanDB(_stringKonekcije);
            string naziv;
            Plan noviPlan = new Plan();

            noviPlan.Datum = _datum;
            noviPlan.IdVrste = planDB.DajIdPremaNazivuTreninga(_nazivTreninga);
            noviPlan.Vreme = _vreme;
            noviPlan.Opis = _opis;

            uspehSnimanja = planDB.DodajNoviPlan(noviPlan);

            return uspehSnimanja;
        }

    }
}


