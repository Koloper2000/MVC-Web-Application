using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class Plan
    {

        //atributi
        private int _idPlan;
        private string _datum;
        private string _vreme;
        private string _opis;
        private int _idVrste;

        //property
        public int IdPlan
        {
            get { return _idPlan; }
            set { _idPlan = value; }
        }

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

        public int IdVrste
        {
            get { return _idVrste; }
            set { _idVrste = value; }
        }

    }
}
