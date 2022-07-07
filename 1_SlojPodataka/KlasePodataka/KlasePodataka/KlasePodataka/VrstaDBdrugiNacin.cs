using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtils;

namespace KlasePodataka
{
    public class VrstaDBdrugiNacin : TabelaClass
    {
        public VrstaDBdrugiNacin(KonekcijaClass konekcijaParametar, string nazivTabeleParametar) : base(konekcijaParametar, nazivTabeleParametar)
       
        {
         
        }
        public DataSet DajSveVrste()
        {
            DataSet podaciDataSet = new DataSet();
            podaciDataSet = this.DajPodatke("Select * from Vrsta");
            return podaciDataSet;
        }

        public string DajVrstuPoNazivu(string nazivTreningaParametar)
        {
            string nazivTreninga = "";

            DataSet podaciDataSet = new DataSet();
            podaciDataSet = this.DajPodatke("Select * from Vrsta where NazivTreninga='" + nazivTreningaParametar + "'");
            try
            {
                if (podaciDataSet.Tables[0].Rows.Count > 0)
                {
                    nazivTreninga = podaciDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    nazivTreninga = "";
                }
            }
            catch (Exception greska)
            {
                nazivTreninga = "";
            }
            return nazivTreninga;
        }

        public bool DodajNovuVrstu(Vrsta novaVrstaObjectParametar)
        {
            bool uspeh = false;
            uspeh = this.IzvrsiAzuriranje("INSERT INTO Vrsta(IDVrste, NazivTreninga) VALUES ('" + novaVrstaObjectParametar.IdVrste + "', '" + novaVrstaObjectParametar.NazivTreninga + "')");
            return uspeh;
        }

        public bool ObrisiVrstu(Vrsta vrstaZaBrisanjeObjectParametar)
        {
            bool uspeh = false;
            uspeh = this.IzvrsiAzuriranje("DELETE from Vrsta where NazivTreninga='" + vrstaZaBrisanjeObjectParametar.NazivTreninga + "'");
            return uspeh;

        }

        public bool IzmeniVrstu(Vrsta staraVrstaObjectParametar, Vrsta novaVrstaObjectParametar)
        {
            bool uspeh = false;
            string upit = "";
            upit = "UPDATE Vrsta set NazivTreninga='" + novaVrstaObjectParametar.NazivTreninga + "' WHERE IDVrste='" + staraVrstaObjectParametar.IdVrste + "'";
            uspeh = this.IzvrsiAzuriranje(upit);
            return uspeh;

        }

    }
}
