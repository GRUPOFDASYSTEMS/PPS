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
    public partial class facturacion_detalle_facturas_clientes : System.Web.UI.Page
    {
        linkeo link = new linkeo();

        protected void Page_Load(object sender, EventArgs e)
        {
            obtener_datosc(); 
        }


        protected void obtener_datosc(){




            id_factura.Text = Session["id_factura"].ToString() ;
            cliente.Text = link.obtener_dato(" cliente where id=" + link.obtener_dato(" facturas where id=" + id_factura.Text, 9), 1);





            
        }


    }
}
