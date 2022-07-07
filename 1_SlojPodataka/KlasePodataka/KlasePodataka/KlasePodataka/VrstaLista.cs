using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class VrstaLista
    {

        //atributi
        private List<Vrsta> _listaVrsta;

        //property
        public List<Vrsta> ListaVrsta
        {
            get
            {
                return _listaVrsta;
            }
            set
            {
                if (this._listaVrsta != value)
                    this._listaVrsta = value;
            }
        }

        //konstruktor
        public VrstaLista()
        {
            _listaVrsta = new List<Vrsta>();
        }

        //javne metode
        public void DodajElementListe(Vrsta vrstaObjekat)
        {
            _listaVrsta.Add(vrstaObjekat);
        }

        public void ObrisiElementListe(Vrsta vrstaObjekatZaBrisanje)
        {
            _listaVrsta.Remove(vrstaObjekatZaBrisanje);
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            _listaVrsta.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(Vrsta staraVrsta, Vrsta novaVrsta)
        {
            int indeksStareVrste = 0;
            indeksStareVrste = _listaVrsta.IndexOf(novaVrsta);
            _listaVrsta.RemoveAt(indeksStareVrste);
            _listaVrsta.Insert(indeksStareVrste, novaVrsta);
        }

    }
}
