using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaPlanDetaljiEdit
    {

        //atributi
        private string _stringKonekcije;
        private PlanDB _planDB;

        private Plan _preuzetPlan;
        private Plan _izmenjenPlan;

        private int _idPlanPreuzeto;
        private string _datumPreuzeto;
        private string _vremePreuzeto;
        private string _opisPreuzeto;
        private string _vrstaPreuzeto;

        private int _idPlanIzmenjeno;
        private string _datumIzmenjeno;
        private string _vremeIzmenjeno;
        private string _opisIzmenjeno;
        private string _vrstaIzmenjeno;

        //property
        public int IdPlanPreuzeto
        {
            get { return _idPlanPreuzeto; }
            set { _idPlanPreuzeto = value; }
        }


        public string DatumPreuzeto
        {
            get { return _datumPreuzeto; }
            set { _datumPreuzeto = value; }
        }

        public string VremePreuzeto
        {
            get { return _vremePreuzeto; }
            set { _vremePreuzeto = value; }
        }
        public string OpisPreuzeto
        {
            get { return _opisPreuzeto; }
            set { _opisPreuzeto = value; }
        }

        public String VrstaPreuzeto
        {
            get { return _vrstaPreuzeto; }
            set { _vrstaPreuzeto = value; }
        }

        public int IdPlanIzmenjeno
        {
            get { return _idPlanIzmenjeno; }
            set { _idPlanIzmenjeno = value; }
        }

        public string DatumIzmenjeno
        {
            get { return _datumIzmenjeno; }
            set { _datumIzmenjeno = value; }
        }

        public string VremeIzmenjeno
        {
            get { return _vremeIzmenjeno; }
            set { _vremeIzmenjeno = value; }
        }
        public string OpisIzmenjeno
        {
            get { return _opisIzmenjeno; }
            set { _opisIzmenjeno = value; }
        }

        public String VrstaIzmenjeno
        {
            get { return _vrstaIzmenjeno; }
            set { _vrstaIzmenjeno = value; }
        }


        //konstruktor 
        public FormaPlanDetaljiEdit(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
            _planDB = new PlanDB(_stringKonekcije);
        }

        //javne metode
        public bool ObrisiPlan()
        {
            bool uspehBrisanja = false;
            uspehBrisanja = _planDB.ObrisiPlan(_idPlanPreuzeto);
            return uspehBrisanja;
        }

        public bool IzmeniPlan()
        {
            bool uspehIzmene = false;
            _preuzetPlan = new Plan();
            _izmenjenPlan = new Plan();

            _preuzetPlan.IdPlan = _idPlanPreuzeto;         
            _preuzetPlan.Datum = _datumPreuzeto;
            _preuzetPlan.Vreme = _vremePreuzeto;
            _preuzetPlan.Opis = _opisPreuzeto;
            _preuzetPlan.IdVrste = Convert.ToInt32(_vrstaPreuzeto);

            _izmenjenPlan.IdPlan = _idPlanIzmenjeno;
            _izmenjenPlan.Datum = _datumIzmenjeno;
            _izmenjenPlan.Vreme = _vremeIzmenjeno;
            _izmenjenPlan.Opis = _opisIzmenjeno;
            _izmenjenPlan.IdVrste = Convert.ToInt32(_planDB.DajIdPremaNazivuTreninga(_vrstaIzmenjeno));

            bool vecPostojiPlanZaTermin = false;
            vecPostojiPlanZaTermin = _planDB.ProveriIzmenuPlana(_izmenjenPlan);
            if (!vecPostojiPlanZaTermin)
            {
                uspehIzmene = _planDB.IzmeniPlan(_preuzetPlan, _izmenjenPlan);
            }
            else
            {
                uspehIzmene = false;
            }

            


            return uspehIzmene;
        }
    }
}
