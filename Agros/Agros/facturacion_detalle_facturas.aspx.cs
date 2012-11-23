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
    public partial class facturacion_detalle_facturas : System.Web.UI.Page
    {
        linkeo linker = new linkeo();

        protected void Page_Load(object sender, EventArgs e)
        {
            obtener_datos(); 
        }


        protected void obtener_datos(){
            
            id_factura.Text = Session["id_factura"].ToString() ;
            cliente.Text = linker.obtener_dato(" cliente where id=" + linker.obtener_dato(" facturas where id=" + id_factura.Text, 9), 1);

            if (Session["cliente"].ToString().Equals("0")) {
                VolverC.Visible = false;
                VolverU.Visible = true; 
            }
            
        }


    }
}
