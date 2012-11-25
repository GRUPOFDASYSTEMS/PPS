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
    public partial class modulo_servicios_listado_detalle_orden : System.Web.UI.Page
    {

        linkeo linker = new linkeo();
 

        protected void Page_Load(object sender, EventArgs e)
        {
            interpretar_instancia();
        }


        public void interpretar_instancia() { 
        
        string id = Session["id_os"].ToString();
        string creando = linker.obtener_dato_especificado("select id from estados where descripcion='En Proceso de creacion' and tema='orden_servicio' ",0);
        string estado = linker.obtener_dato_especificado("select id_estado from orden_de_servicio where id="+id, 0);


        if (creando.Equals(estado))
            Response.Redirect("modulo_servicios_creando_detalle_orden.aspx");



        }

        protected void dgvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
