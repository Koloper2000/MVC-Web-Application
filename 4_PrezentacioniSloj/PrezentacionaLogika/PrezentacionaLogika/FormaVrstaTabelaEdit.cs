using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaVrstaTabelaEdit
    {
        //atributi
        private string _stringKonekcije;

        //konstruktor
        public FormaVrstaTabelaEdit(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet podaciDataSet = new DataSet();
            VrstaDB vrstaDB = new VrstaDB(_stringKonekcije);
            if (filter.Equals(""))
            {
                podaciDataSet = vrstaDB.DajSveVrste();
            }
            else
            {
                podaciDataSet = vrstaDB.DajVrstuPoNazivu(filter);
            }
            


            return podaciDataSet;
        }

    }

}
