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
    public partial class VrstaStampa : System.Web.UI.Page
    {
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakVrste.DataSource = ds.Tables[0];
            gvSpisakVrste.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            FormaVrstaTabelaEdit podaciZaGrid = new FormaVrstaTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(podaciZaGrid.DajPodatkeZaGrid(""));
        }
    }
}