using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaLogin
    {
        //atributi
        private string _stringKonekcije;
        private string _korisnickoIme;
        private string _sifra;

        //property
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { _korisnickoIme = value; }
        }

        public string Sifra
        {
            get { return _sifra; }
            set { _sifra = value; }
        }

        //konstruktor
        public FormaLogin(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //javne metode
        public bool VazeciKorisnik()
        {
            bool vazeci = false;

            KorisnikDB korisnik = new KorisnikDB(_stringKonekcije);
            DataSet podaciDataSet = korisnik.DajKorisnikaPoKorisnickomImenuISifri(_korisnickoIme, _sifra);

            if(podaciDataSet.Tables[0].Rows.Count > 0)
            {
                vazeci = true;
            }
            else
            {
                vazeci = false;
            }

            return vazeci;
        }

        public string DajImePrezimeKorisnika()
        {
            string imePrezime = "";

            KorisnikDB korisnik = new KorisnikDB(_stringKonekcije);
            DataSet podaciDataSet = korisnik.DajKorisnikaPoKorisnickomImenuISifri(_korisnickoIme, _sifra);

            if(podaciDataSet.Tables[0].Rows.Count > 0)
            {
                imePrezime = podaciDataSet.Tables[0].Rows[0].ItemArray[2].ToString() + " " + podaciDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
            }

            return imePrezime;
        }
    }
}
