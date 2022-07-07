using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class PlanUnos : System.Web.UI.Page
    {
        FormaPlanUnos unosPlana; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KorisnikImePrezime"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                unosPlana = new FormaPlanUnos(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
                if (!IsPostBack)
                {

                    NapuniComboVrste();


                }
            }
            
            
        }

        private void NapuniComboVrste()
        {
            
            DataSet vrstaDataSet = new DataSet();

            vrstaDataSet = unosPlana.DajVrsteZaCombo();
            int ukupnoVrste = vrstaDataSet.Tables[0].Rows.Count;
            VrstaDDL.Items.Add("Izaberite...");
            for(int i = 0; i < ukupnoVrste; i++)
            {
                VrstaDDL.Items.Add(vrstaDataSet.Tables[0].Rows[i].ItemArray[1].ToString());
            }

           
        }
        private void NapuniComboTermini()
        {
            // IZDVAJANJE PODATAKA IZ XML POSREDSTVOM WEB SERVISA
            DataSet vremeDataSet = new DataSet();
            vremeDataSet = unosPlana.DajPodatkeZaComboTermini();
            int ukupnoTermina = vremeDataSet.Tables[0].Rows.Count;
            VremeDDL.Items.Add("Izaberite...");
            for (int i = 0; i < ukupnoTermina; i++)
            {
                VremeDDL.Items.Add(vremeDataSet.Tables[0].Rows[i].ItemArray[0].ToString());
            }
        }


        protected void btnSnimi_Click(object sender, EventArgs e)
        {
            bool svePopunjeno = false;
            bool jedinstvenZapis = false;
            unosPlana.NazivTreninga = VrstaDDL.SelectedValue.ToString();
            if (VrstaDDL.SelectedValue.Equals("Izaberite..."))
            {
                svePopunjeno = false;
            }
            else
            {
                unosPlana.Opis = OpisTxb.Text;
                DateTime date = Calendar1.SelectedDate.Date;
                string preuzetiDatum = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
                unosPlana.Datum = preuzetiDatum;
                unosPlana.Vreme = VremeDDL.SelectedValue.ToString();

                svePopunjeno = unosPlana.DaLiJeSvePopunjeno();
                jedinstvenZapis = unosPlana.DaLiJeJedinstvenZapis();
            }

            if (svePopunjeno)
            {
                if (jedinstvenZapis)
                {
                    unosPlana.SnimiPodatke();
                    lblStatus.Text = "Snimljeno";
                }
                else
                {
                    lblStatus.Text = "Termin je zauzet";
                }

            }
            else
            {
                lblStatus.Text = "Nisu popunjena sva polja";
            }
        }

        protected void btnOdustani_Click(object sender, EventArgs e)
        {
            Response.Redirect("WelcomeAdmin.aspx");
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;

            }
        }
    }
}