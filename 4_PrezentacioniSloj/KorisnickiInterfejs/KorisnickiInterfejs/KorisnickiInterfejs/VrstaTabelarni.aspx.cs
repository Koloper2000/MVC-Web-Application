using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KlasePodataka;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class VrstaTabelarni : System.Web.UI.Page
    {

        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakVrsteTreninga.DataSource = ds.Tables[0];
            gvSpisakVrsteTreninga.DataBind();
        }

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

        protected void gvSpisakVrsteTreninga_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}