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
    public partial class Site1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string mensaje_error = Session["mensaje_error"].ToString();
            if (mensaje_error.Length > 0)
            {
                //muestro alerta
                Response.Write(mensaje_error);
                Session["mensaje_error"] = "";
            }


            string mensaje_exito = Session["mensaje_exito"].ToString();
            if (mensaje_exito.Length > 0)
            {
                //muestro alerta
                Response.Write(mensaje_exito);
                Session["mensaje_exito"] = "";
            }







        }


 

    }
}
