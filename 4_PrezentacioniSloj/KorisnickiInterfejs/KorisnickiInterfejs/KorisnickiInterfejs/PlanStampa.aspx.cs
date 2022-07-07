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
    public partial class PlanStampa : System.Web.UI.Page
    {
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakpPlanova.DataSource = ds.Tables[0];
            gvSpisakpPlanova.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PlanDB plan = new PlanDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            plan.ObrisiPlanNakonIstekaRoka();
            FormaPlanTabelaEdit podaciZaGrid = new FormaPlanTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(podaciZaGrid.DajPodatkeZaGrid(""));
        }
    }
}