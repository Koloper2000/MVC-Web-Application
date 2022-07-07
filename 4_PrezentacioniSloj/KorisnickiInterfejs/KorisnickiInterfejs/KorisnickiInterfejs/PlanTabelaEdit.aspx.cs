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
    public partial class PlanTabelaEdit : System.Web.UI.Page
    {
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakPlanovaEdit.DataSource = ds.Tables[0];
            gvSpisakPlanovaEdit.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KorisnikImePrezime"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                
            }
            if (!IsPostBack)
            {
                PlanDB plan = new PlanDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
                plan.ObrisiPlanNakonIstekaRoka();
                FormaPlanTabelaEdit formaPlan = new FormaPlanTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
                NapuniGrid(formaPlan.DajPodatkeZaGrid(""));
            }
        }


        protected void gvSpisakPlanovaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("PlanDetaljiEdit.aspx?IDPlan=" + gvSpisakPlanovaEdit.Rows[gvSpisakPlanovaEdit.SelectedIndex].Cells[1].Text);
        }
    }
}