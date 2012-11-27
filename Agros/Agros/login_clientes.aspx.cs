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
    public partial class login_clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mensaje_exito = Session["mensaje_exito"].ToString();
            if (mensaje_exito.Length > 0)
            {
                //muestro alerta
                Response.Write(mensaje_exito);
                Session["mensaje_exito"] = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            linkeo linker = new linkeo();
            string condiciones, id;
           





            condiciones = " cliente where cuit="+TextBox1.Text + " and password=" + TextBox2.Text;

            id = linker.obtener_dato(condiciones, 0);

            if ((id.Equals("-1")) || (TextBox1.Text.Length == 0) || (TextBox2.Text.Length == 0 ))
                Label1.Text = "Error de ingreso, compruebe su nombre de usuario y clave e intente nuevamente";
            else
            {             //existe el usuario, con lo cual lo guardo y sigo

                Session["cliente"] = id;
                Response.Redirect("indice_cliente.aspx");
            }

        }
    }
}
