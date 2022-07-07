using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class KorisnikDB
    {
        //atributi
        private string _stringKonekcije;

        //property
        public string StringKonekcije { get => _stringKonekcije; set => _stringKonekcije = value; }

        //konstruktor
        public KorisnikDB(string NoviStringKonekcije)
        {
            _stringKonekcije = NoviStringKonekcije;
        }

        //javne metode
        public DataSet DajKorisnikaPoKorisnickomImenuISifri(string korisnickoIme, string sifra)
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajKorisnikaPoKorisnickomImenuISifri", veza);
            komanda.Parameters.Add("@KorisnickoIme", SqlDbType.NVarChar).Value = korisnickoIme;
            komanda.Parameters.Add("@Sifra", SqlDbType.NVarChar).Value = sifra;
            komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();


            return podaciDataSet;
        }

    }
}
