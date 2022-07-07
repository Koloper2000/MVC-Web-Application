using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class VrstaDB
    {
        //atributi
        private string _stringKonekcije;

        //property
        public string StringKonekcije
        {
            get
            {
                return _stringKonekcije;
            }
        }

        //konstruktor
        public VrstaDB(string noviStringKonekcije)
        {
            _stringKonekcije = noviStringKonekcije;
        }

        //javne metode
        public DataSet DajSveVrste()
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajSveVrste", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;
        }

        public DataSet DajVrstuPoNazivu(string nazivTreninga)
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajVrstuPoNazivu", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@NazivTreninga", SqlDbType.NVarChar).Value = nazivTreninga;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;
        }

        public bool DodajNovuVrstu(Vrsta novaVrsta)
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("DodajNovuVrstu", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@NazivTreninga", SqlDbType.NVarChar).Value = novaVrsta.NazivTreninga;

            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);
        }

        public bool ObrisiVrstu(string nazivVrsteZaBrisanje)
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("ObrisiVrstu", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@NazivTreninga", SqlDbType.NVarChar).Value = nazivVrsteZaBrisanje;
            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);
        }

        public bool IzmeniVrstu(Vrsta staraVrsta, Vrsta novaVrsta)
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("IzmeniVrstu", veza);
            komanda.CommandType = CommandType.StoredProcedure;

            komanda.Parameters.Add("@StariId", SqlDbType.Int).Value = staraVrsta.IdVrste;
            komanda.Parameters.Add("@NazivTreninga", SqlDbType.NVarChar).Value = novaVrsta.NazivTreninga;
      
            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);

        }


    }
}
