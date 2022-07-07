using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class PlanLista
    {

        //atributi
        private List<Plan> _listaPlanova;

        //property
        public List<Plan> ListaPlanova
        {
            get
            {
                return _listaPlanova;
            }
            set
            {
                if (this._listaPlanova != value)
                    this._listaPlanova = value;
            }
        }

        //konsktruktor
        public PlanLista()
        {
            _listaPlanova = new List<Plan>();
        }

        //javne metode
        public void DodajElementListe(Plan noviPlan)
        {
            _listaPlanova.Add(noviPlan);
        }

        public void ObrisiElementListe(Plan planZaBrisanje)
        {
            _listaPlanova.Remove(planZaBrisanje);             
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            _listaPlanova.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(Plan stariPlan, Plan noviPlan)
        {
            int indeksStarogPlana = 0;
            indeksStarogPlana = _listaPlanova.IndexOf(noviPlan);
            _listaPlanova.RemoveAt(indeksStarogPlana);
            _listaPlanova.Insert(indeksStarogPlana, noviPlan);
        }

    }
}
