using KlasePodataka;
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
    public partial class VrstaTabelaEdit : System.Web.UI.Page
    {

        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakVrsteEdit.DataSource = ds.Tables[0];
            gvSpisakVrsteEdit.DataBind();
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

            if (!IsPostBack)
            {
                
                FormaVrstaTabelaEdit formaVrstaTabelaEdit = new FormaVrstaTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
                NapuniGrid(formaVrstaTabelaEdit.DajPodatkeZaGrid(""));
            }
            
        }

        protected void gvSpisakVrsteEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("VrstaDetaljiEdit.aspx?NazivTreninga=" + gvSpisakVrsteEdit.Rows[gvSpisakVrsteEdit.SelectedIndex].Cells[2].Text);
        }
    }
}