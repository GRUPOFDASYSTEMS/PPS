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
    public partial class abmservicios_ver_productos_necesarios : System.Web.UI.Page
    {

        /* Globales */
        string idds, id = "";
        nueva_pagina np = new nueva_pagina();
        linkeo linker = new linkeo();
        puente puente = new puente();



        protected void Page_Load(object sender, EventArgs e)
        {
            idds = Session["id_detalle_servicio"].ToString();


            if (idds.Equals("0"))
                Session["mensaje_error"] = "sin log";
            else
                Lidds.Text = linker.obtener_dato_especificado("select descripcion from detalle_servicio where id=" + idds, 0);



        }

        protected void dgvdatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[1].Text;
            //this.Label1.Text = id;
            puente.elimina(id, "producto_necesario");
            Response.Redirect("abmservicios_ver_productos_necesarios.aspx");        

        }
    }
}
