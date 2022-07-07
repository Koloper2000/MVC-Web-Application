using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class Vrsta
    {
        //atributi
        private int _idVrste;
        private string _nazivTreninga;

        //property
        public int IdVrste
        {
            get { return _idVrste; }
            set { _idVrste = value; }
        }

        public string NazivTreninga
        {
            get { return _nazivTreninga; }
            set { _nazivTreninga = value; }
        }
    }
}
