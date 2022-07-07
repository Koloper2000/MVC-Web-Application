using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;
using KlasePodataka;

namespace KorisnickiInterfejs
{
    public partial class VrstaDetaljiEdit : System.Web.UI.Page
    {
        //atributi
        private string _nazivTreninga;
        FormaVrstaDetaljiEdit formaDetaljiEdit;
        VrstaDB vrstaDB;
        DataSet podaciDataSet;


        private void PrikaziPodatke(FormaVrstaDetaljiEdit formaDetaljiEdit)
        {
            NazivTreningatxb.Text = formaDetaljiEdit.NazivPreuzeteVrste;
        }

        private void IsprazniKontrole()
        {
            NazivTreningatxb.Text = "";
        }

        private void AktivirajKontrole()
        {
            NazivTreningatxb.Enabled = true;
        }

        private void DeaktivirajKontrole()
        {
            NazivTreningatxb.Enabled = false;
        }

        //konstruktor
        public VrstaDetaljiEdit()
        {
            vrstaDB = new VrstaDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["KorisnikImePrezime"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                formaDetaljiEdit = new FormaVrstaDetaljiEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                _nazivTreninga = Request.QueryString["NazivTreninga"].ToString();
                podaciDataSet = new DataSet();
                podaciDataSet = vrstaDB.DajVrstuPoNazivu(_nazivTreninga);   
                    formaDetaljiEdit.IdPreuzeteVrste = Convert.ToInt32(podaciDataSet.Tables[0].Rows[0].ItemArray[0].ToString());
                    formaDetaljiEdit.NazivPreuzeteVrste = podaciDataSet.Tables[0].Rows[0].ItemArray[1].ToString();

                if (!IsPostBack)
                {
                    PrikaziPodatke(formaDetaljiEdit);
                }
            }

           
        }

        protected void btnIzmeni_Click(object sender, EventArgs e)
        {
            formaDetaljiEdit.NazivIzmenjeneVrste = NazivTreningatxb.Text;


            bool uspehIzmene = formaDetaljiEdit.IzmeniVrstu();
            if (uspehIzmene)
            {
                lblStatus.Text = "Uspesno izmenjen zapis";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "Zapis nije izmenjen";
            }
            DeaktivirajKontrole();

        }

        protected void btnOdustani_Click(object sender, EventArgs e)
        {
            formaDetaljiEdit.NazivPreuzeteVrste = NazivTreningatxb.Text;
            bool uspehBrisanja = formaDetaljiEdit.ObrisiVrstu();
            if (uspehBrisanja)
            {
                lblStatus.Text = "Uspesno obrisan zapis!";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "Zapis nije obrisan";
            }
        }
    }
}