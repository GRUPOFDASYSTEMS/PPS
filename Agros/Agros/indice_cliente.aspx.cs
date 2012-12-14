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

        protected void limpio_variables_de_sesion()
        {

            //de sesion
            Session["usuario"] = "0";
            Session["cliente"] = "0";
            Session["perfil"] = "0";

            //genericos
            Session["mensaje_exito"] = "";
            Session["mensaje_error"] = "";


            //de id
            Session["id_factura"] = "0";
            Session["id_os"] = "0";
            Session["id_servicio"] = "0";
            Session["id_detalle_servicio"] = "0";

        }

        protected void salir()
        {
            //codigo de salida
            limpio_variables_de_sesion();

            Response.Redirect("inicio.aspx");


        }


        protected void Salir_Click(object sender, EventArgs e)
        {
            salir();
        }





    }
}
