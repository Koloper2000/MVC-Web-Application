using KlasePodataka;
using PrezentacionaLogika;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KorisnickiInterfejs
{
    public partial class PlanTabelarniNeregistrovani : System.Web.UI.Page
    {

        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakPlanova.DataSource = ds.Tables[0];
            gvSpisakPlanova.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PlanDB plan = new PlanDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            plan.ObrisiPlanNakonIstekaRoka();
        }

        protected void btnFiltriraj_Click(object sender, EventArgs e)
        {
            DateTime date = Calendar1.SelectedDate.Date;
            string preuzetiDatum = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
            FormaPlanTabelaEdit podaciZaGrid = new FormaPlanTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(podaciZaGrid.DajPodatkeZaGrid(preuzetiDatum));
        }

        protected void btnSvi_Click(object sender, EventArgs e)
        {
            FormaPlanTabelaEdit podaciZaGrid = new FormaPlanTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(podaciZaGrid.DajPodatkeZaGrid(""));
        }
    }
}