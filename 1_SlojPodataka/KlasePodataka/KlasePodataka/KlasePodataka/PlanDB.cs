using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class PlanDB
    {

        //atributi
        private string _stringKonekcije;

        //property
        public string StringKonekcije
        {
            get { return _stringKonekcije; }
        }

        //konstruktor
        public PlanDB(string NoviStringKonekcije)
        {
            _stringKonekcije = NoviStringKonekcije;
        }

        public DataSet DajSvePlanoveSaJoin()
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajSvePlanoveSaJoin", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;
        }

        public DataSet DajPlanovePoDatumu(string datum)
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajPlanovePoDatumu", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@Datum", SqlDbType.Date).Value = datum;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;
        }

        public DataSet DajPlanPremaDatumuIVremenu(Plan proveraPlana)
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajPlanPremaDatumuIVremenu", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@Datum", SqlDbType.Date).Value = proveraPlana.Datum;
            komanda.Parameters.Add("@Vreme", SqlDbType.NVarChar).Value = proveraPlana.Vreme;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;
        }

        public int DajIdPremaNazivuTreninga(string nazivTreninga)
        {
            int idPlan;

            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajIdPremaNazivuTreninga", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@NazivTreninga", SqlDbType.NVarChar).Value = nazivTreninga;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = komanda;
            da.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();
            idPlan = Convert.ToInt32(podaciDataSet.Tables[0].Rows[0].ItemArray[0].ToString());
            return idPlan;




        }

        public string DajNazivTreningaPoId(int idVrste)
        {
            string nazivTreninga;

            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajNazivTreningaPoId", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@IDVrste", SqlDbType.Int).Value = idVrste;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = komanda;
            da.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            nazivTreninga = podaciDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
            return nazivTreninga;

        }


        public DataSet DajPlanPoId(int idPlan)
        {
            DataSet podaciDataSet = new DataSet();

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajPlanPoId", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@IDPlan", SqlDbType.Int).Value = idPlan;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komanda;
            dataAdapter.Fill(podaciDataSet);
            veza.Close();
            veza.Dispose();

            return podaciDataSet;
        }


        public bool ProveriIzmenuPlana(Plan proveraPlana)
        {
            DataSet podaciDataSet = new DataSet();
            int brojSlogova = 0;
            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();
            SqlCommand komanda = new SqlCommand("DajPlanPremaDatumuIVremenu", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@Datum", SqlDbType.Date).Value = proveraPlana.Datum;
            komanda.Parameters.Add("@Vreme", SqlDbType.NVarChar).Value = proveraPlana.Vreme;
            brojSlogova = komanda.ExecuteNonQuery();

            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);
        }

        public bool DodajNoviPlan(Plan noviPlan)
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("DodajNoviPlan", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@Datum", SqlDbType.Date).Value = noviPlan.Datum;
            komanda.Parameters.Add("@Vreme", SqlDbType.NVarChar).Value = noviPlan.Vreme;
            komanda.Parameters.Add("@Opis", SqlDbType.Text).Value = noviPlan.Opis;
            komanda.Parameters.Add("@IDVrste", SqlDbType.Int).Value = noviPlan.IdVrste;

            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);

        }

        public bool ObrisiPlan(int idPlanZaBrisanje)
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("ObrisiPlan", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@IDPlan", SqlDbType.Int).Value = idPlanZaBrisanje;
            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);
        }

        public bool ObrisiPlanNakonIstekaRoka()
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("ObrisiPlanNakonIstekaRoka", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);

        }

        public bool IzmeniPlan(Plan stariPlan, Plan noviPlan)
        {
            int brojSlogova = 0;

            SqlConnection veza = new SqlConnection(_stringKonekcije);
            veza.Open();

            SqlCommand komanda = new SqlCommand("IzmeniPlan", veza);
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.Parameters.Add("@StariIdPlana", SqlDbType.Int).Value = stariPlan.IdPlan;
            komanda.Parameters.Add("@Datum", SqlDbType.Date).Value = noviPlan.Datum;
            komanda.Parameters.Add("@Vreme", SqlDbType.NVarChar).Value = noviPlan.Vreme;
            komanda.Parameters.Add("@Opis", SqlDbType.Text).Value = noviPlan.Opis;
            komanda.Parameters.Add("@IDVrste", SqlDbType.Int).Value = noviPlan.IdVrste;
            brojSlogova = komanda.ExecuteNonQuery();
            veza.Close();
            veza.Dispose();

            return (brojSlogova > 0);

        }

    }
}
