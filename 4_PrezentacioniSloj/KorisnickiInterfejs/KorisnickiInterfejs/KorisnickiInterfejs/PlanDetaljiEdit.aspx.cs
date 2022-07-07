using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;
using KlasePodataka;
using System.Data;
using System.Configuration;

namespace KorisnickiInterfejs
{
    public partial class PlanDetaljiEdit : System.Web.UI.Page
    {
        private int _idPlana;
        FormaPlanDetaljiEdit formaDetaljiEdit;
        PlanDB planDB;
        DataSet podaciDataSet;
        FormaPlanUnos plan;

        private void PrikaziPodatke(FormaPlanDetaljiEdit formaPlanDetaljiEdit)
        {
            podaciDataSet = planDB.DajSvePlanoveSaJoin();
            DataSet vrstaDataSet = new DataSet();
            DataSet vremeDataSet = new DataSet();

            vrstaDataSet = plan.DajVrsteZaCombo();
            int ukupnoVrste = vrstaDataSet.Tables[0].Rows.Count;
            VrstaDDL.Items.Add("Izaberite...");
            for (int i = 0; i < ukupnoVrste; i++)
            {
                VrstaDDL.Items.Add(vrstaDataSet.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            VrstaPrethodnaVrednostLabel.Text = "Prethodna vrednost: " + planDB.DajNazivTreningaPoId(Convert.ToInt32(formaPlanDetaljiEdit.VrstaPreuzeto));

            vremeDataSet = plan.DajPodatkeZaComboTermini();
            int ukupnoTermina = vremeDataSet.Tables[0].Rows.Count;
            VremeDDL.Items.Add("Izaberite...");
            for (int i = 0; i < ukupnoTermina; i++)
            {
                VremeDDL.Items.Add(vremeDataSet.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            VremePrethodnaVrednostLabel.Text = "Prethodna vrednost: " + formaPlanDetaljiEdit.VremePreuzeto;

            Calendar1.SelectedDate = Convert.ToDateTime(formaPlanDetaljiEdit.DatumPreuzeto);

            OpisTxb.Text = formaPlanDetaljiEdit.OpisPreuzeto;

        }

        private void IsprazniKontrole()
        {
            VrstaDDL.ClearSelection();
            VremeDDL.ClearSelection();
            OpisTxb.Text = "";
        }

        private void AktivirajKontrole()
        {
            VrstaDDL.Enabled = true;
            OpisTxb.Enabled = true;
            Calendar1.Enabled = true;
            VremeDDL.Enabled = true; 
        }

        private void DeaktivirajKontrole()
        {
            VrstaDDL.Enabled = false;
            OpisTxb.Enabled = false;
            Calendar1.Enabled = false;
            VremeDDL.Enabled = false;
        }

        public PlanDetaljiEdit()
        {
            planDB = new PlanDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KorisnikImePrezime"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                plan = new FormaPlanUnos(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                formaDetaljiEdit = new FormaPlanDetaljiEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                _idPlana = int.Parse(Request.QueryString["IDPlan"].ToString());
                podaciDataSet = new DataSet();
                podaciDataSet = planDB.DajPlanPoId(Convert.ToInt32(_idPlana));                
                formaDetaljiEdit.IdPlanPreuzeto = Convert.ToInt32(podaciDataSet.Tables[0].Rows[0].ItemArray[0].ToString());
                formaDetaljiEdit.DatumPreuzeto = podaciDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
                formaDetaljiEdit.VremePreuzeto = podaciDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
                formaDetaljiEdit.OpisPreuzeto = podaciDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
                formaDetaljiEdit.VrstaPreuzeto = podaciDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
            

            if (!IsPostBack)
                {
                    PrikaziPodatke(formaDetaljiEdit);
                }
            }

            

        }

        protected void btnIzmeni_Click(object sender, EventArgs e)
        {
            formaDetaljiEdit.OpisIzmenjeno = OpisTxb.Text;
            formaDetaljiEdit.VrstaIzmenjeno = VrstaDDL.SelectedValue;
            DateTime date = Calendar1.SelectedDate.Date;
            string preuzetiDatum = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
            formaDetaljiEdit.DatumIzmenjeno = preuzetiDatum;
            formaDetaljiEdit.VremeIzmenjeno = VremeDDL.SelectedValue;

            bool uspehIzmene = formaDetaljiEdit.IzmeniPlan();
            if (uspehIzmene)
            {
                lblStatus.Text = "Uspesno izmenjen zapis";
            }
            else
            {
                lblStatus.Text = "Zapis nije izmenjen";
            }
            DeaktivirajKontrole();

        }

        protected void btnObrisi_Click(object sender, EventArgs e)
        {
            formaDetaljiEdit.IdPlanPreuzeto = Convert.ToInt32(podaciDataSet.Tables[0].Rows[0].ItemArray[0].ToString());
            bool uspehBrisanja = formaDetaljiEdit.ObrisiPlan();
            if (uspehBrisanja)
            {
                lblStatus.Text = "Uspesno obrisan plan";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "Plan nije obrisan";
            }
        }
    }
}