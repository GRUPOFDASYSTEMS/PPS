using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Agros
{
    public partial class indice_cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Salir_Click(object sender, EventArgs e)
        {
            /* Limpio todas las variables de sesion... */
            Session["cliente"] = "0";
            Session["mensaje_exito"] = "";
            Session["mensaje_error"] = "";

            /*Y vuelvo al login*/
            Response.Redirect("login_clientes.aspx");


        }
    }
}
