using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using PrezentacionaLogika;
using System.Configuration;

namespace KorisnickiInterfejs
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPRIJAVA_Click(object sender, EventArgs e)
        {
            // provera korisnika 
            FormaLogin formaLogin = new FormaLogin(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            formaLogin.KorisnickoIme = txbKorisnickoIme.Text;
            formaLogin.Sifra = txbSifra.Text; 
            bool pronadjenKorisnik = formaLogin.VazeciKorisnik();

            if (pronadjenKorisnik)
            {
                // TO DO
                string ImePrezime = formaLogin.DajImePrezimeKorisnika();

                // ubacivanje korisnika u sesiju
                Session.Add("KorisnikImePrezime", ImePrezime);

                // ucitavanje Welcome admin
                Response.Redirect("WelcomeAdmin.aspx");
            }
            else
            {
                lblStatus.Text = "KORISNIK NIJE PRONADJEN!"; 
            }

        }

        protected void btnOdustani_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}