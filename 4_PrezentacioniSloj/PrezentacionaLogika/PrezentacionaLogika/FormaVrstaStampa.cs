using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaVrstaStampa
    {

        //atributi
        private string _stringKonekcije;

        //konstruktor
        public FormaVrstaStampa(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //javne metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet podaciDataSet = new DataSet();
            VrstaDB _vrstaDB = new VrstaDB(_stringKonekcije);

            if (filter.Equals(""))
            {
                podaciDataSet = _vrstaDB.DajSveVrste();
            }
            else
            {
                podaciDataSet = _vrstaDB.DajVrstuPoNazivu(filter);
            }

            return podaciDataSet;
        }
    }
}
