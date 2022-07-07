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
    public partial class VrstaTabelarniNeregistrovani : System.Web.UI.Page
    {

        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakVrsteTreninga.DataSource = ds.Tables[0];
            gvSpisakVrsteTreninga.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnFiltriraj_Click(object sender, EventArgs e)
        {
            FormaVrstaTabelaEdit podaciZaGrid = new FormaVrstaTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(podaciZaGrid.DajPodatkeZaGrid(Filtertxb.Text));
        }

        protected void btnSvi_Click(object sender, EventArgs e)
        {
            FormaVrstaTabelaEdit podaciZaGrid = new FormaVrstaTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(podaciZaGrid.DajPodatkeZaGrid(""));
        }
    }
}