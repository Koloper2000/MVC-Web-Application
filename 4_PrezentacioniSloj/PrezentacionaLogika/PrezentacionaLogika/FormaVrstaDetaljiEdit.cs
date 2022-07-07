using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaVrstaDetaljiEdit
    {
        //atributi
        private string _stringKonekcije;
        private VrstaDB _vrstaDB;
        private Vrsta _preuzetaVrsta;
        private Vrsta _izmenjenaVrsta;

        private int _idPreuzeteVrste;
        private string _nazivPreuzeteVrste;

        private int _idIzmenjeneVrste;
        private string _nazivIzmenjeneVrste;

        //property
        //property
        public int IdPreuzeteVrste
        {
            get { return _idPreuzeteVrste; }
            set { _idPreuzeteVrste = value; }
        }

        public string NazivPreuzeteVrste
        {
            get { return _nazivPreuzeteVrste; }
            set { _nazivPreuzeteVrste = value; }
        }

       

        public int IdIzmenjeneVrste
        {
            get { return _idIzmenjeneVrste; }
            set { _idIzmenjeneVrste = value; }
        }

        public string NazivIzmenjeneVrste
        {
            get { return _nazivIzmenjeneVrste; }
            set { _nazivIzmenjeneVrste = value; }
        }

       


        //konstruktor
        public FormaVrstaDetaljiEdit(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
            _vrstaDB = new VrstaDB(_stringKonekcije);
        }


        //javne metode
        public bool ObrisiVrstu()
        {
            bool uspehBrisanja = false;
            uspehBrisanja = _vrstaDB.ObrisiVrstu(_nazivPreuzeteVrste);

            return uspehBrisanja;
        }

        public bool IzmeniVrstu()
        {
            bool uspehIzmene = false;
            _preuzetaVrsta = new Vrsta();
            _izmenjenaVrsta = new Vrsta();

            _preuzetaVrsta.NazivTreninga = _nazivPreuzeteVrste;
            _preuzetaVrsta.IdVrste = _idPreuzeteVrste;

            _izmenjenaVrsta.NazivTreninga = _nazivIzmenjeneVrste;
            _izmenjenaVrsta.IdVrste = _idIzmenjeneVrste;
           

            uspehIzmene = _vrstaDB.IzmeniVrstu(_preuzetaVrsta, _izmenjenaVrsta);

            return uspehIzmene;
        }

    }
}
