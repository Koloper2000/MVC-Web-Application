using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaPlanTabelaEdit
    {

        //atributi
        private string _stringKonekcije;

        //konstruktor
        public FormaPlanTabelaEdit(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //javne metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet podaciDataSet = new DataSet();
            PlanDB planDB = new PlanDB(_stringKonekcije);
            if(filter.Equals(""))
            {
                podaciDataSet = planDB.DajSvePlanoveSaJoin();
            }
            else
            {
                podaciDataSet = planDB.DajPlanovePoDatumu(filter);
            }
            PlanDB plan = new PlanDB(_stringKonekcije);
            plan.ObrisiPlanNakonIstekaRoka();

            return podaciDataSet;
        }
    }
}
