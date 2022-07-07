using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;


namespace KorisnickiInterfejs
{
    public partial class VrstaUnos : System.Web.UI.Page
    {

        FormaVrstaUnos unosVrste;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KorisnikImePrezime"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    //onda
                }
            }
            unosVrste = new FormaVrstaUnos(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());

        }

        protected void btnSnimi_Click(object sender, EventArgs e)
        {
            KlasePodataka.VrstaDB vrstaDB = new KlasePodataka.VrstaDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            KlasePodataka.Vrsta vrsta = new KlasePodataka.Vrsta();

            unosVrste.NazivTreninga = NazivTreningatxb.Text;
            

            
            
            bool svePopunjeno = unosVrste.DaLiJeSvePopunjeno();
            bool jedinstvenZapis = unosVrste.DaLiJeJedinstvenZapis();

            if(svePopunjeno)
            {
                if (jedinstvenZapis)
                {
                    unosVrste.SnimiPodatke();
                    lblStatus.Text = "Snimljeno";
                }
                else
                {
                    lblStatus.Text = "Podaci o vrsti vec postoje u bazi";
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
    }
}