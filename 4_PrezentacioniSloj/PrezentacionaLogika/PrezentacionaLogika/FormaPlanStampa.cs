using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlasePodataka;
using System.Data;

namespace PrezentacionaLogika
{
    public class FormaPlanStampa
    {

        //atributi
        private string _stringKonekcije;

        //konstruktor
        public FormaPlanStampa(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //javne metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet podaciDataSet = new DataSet();
            PlanDB planDB = new PlanDB(_stringKonekcije);

            if (filter.Equals(""))
            {
                podaciDataSet = planDB.DajSvePlanoveSaJoin();
            }
            else
            {
                podaciDataSet = planDB.DajPlanovePoDatumu(filter);
            }

            return podaciDataSet;
        }
    }
}
