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
    public partial class abmservicios_listado_detalle : System.Web.UI.Page
    {
        linkeo linker = new linkeo();
        puente puente = new puente();
        nueva_pagina np = new nueva_pagina(); 
        string id, rm, resultado;

        protected void Page_Load(object sender, EventArgs e)
        {

        }




        protected void dgvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[1].Text;
            this.Label2.Text = id;
            
        }

        protected void x_Click(object sender, EventArgs e)
        {
            id = this.Label2.Text;

            if ((rm = np.mensaje_marca(id)).Length < 1)
            {
                //primero elimino las dependencias (en producto_necesario)luego el valor padre
                resultado = puente.elimina_hijo_y_padre(id, "DELETE FROM producto_necesario WHERE id_detalle_servicio=", "detalle_servicio");

                string[] devolucion = new string[3];
                devolucion = linker.revisar_error(resultado, "DEL", "Datos Eliminados Correctamente", "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion", "abmservicios_listado_detalle.aspx", "abmservicios_listado_detalle.aspx");


                if (devolucion[0].Equals("0"))
                    Session["mensaje_error"] = devolucion[1];
                else
                    Session["mensaje_exito"] = devolucion[1];

                //Valido en el caso que no acepte...
                if (resultado.Equals("No Acepto"))
                    Session["mensaje_error"] = "";

                Response.Redirect(devolucion[2]);

            }
            else
                Response.Write(rm);

        }

        protected void ver_Click(object sender, EventArgs e)
        {

            id = this.Label2.Text;

            if ((rm = np.mensaje_marca(id)).Length < 1)
            {
                Session["id_detalle_servicio"] = id;
                Response.Redirect("abmservicios_ver_productos_necesarios.aspx");
            }
            else
                Response.Write(rm);

        }

        protected void add_Click(object sender, EventArgs e)
        {
            id = this.Label2.Text;

            if ((rm = np.mensaje_marca(id)).Length < 1)
            {

                Session["id_detalle_servicio"] = id;
                Response.Redirect("abmservicios_agregar_producto_necesario.aspx");
            }
            else
                Response.Write(rm);

        }
    }
}
