using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HannProjectOmg
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Url.AbsolutePath.Equals("/InicioSesion") || HttpContext.Current.Request.Url.AbsolutePath.Equals("/Default"))
            {
                btnCerrarSesion.Visible = false;
            }
            else
            {
                if(Session["idUsuario"] == null)
                {
                    Session.Clear();
                    Response.Redirect("/InicioSesion");
                }
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/InicioSesion");
        }
    }
}