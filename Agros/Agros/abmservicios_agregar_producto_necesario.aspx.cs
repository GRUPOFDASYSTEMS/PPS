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
    public partial class abmservicios_agregar_producto_necesario : System.Web.UI.Page
    {
        /* Globales */
        string idds, id="", resultado, rm;
        nueva_pagina np = new nueva_pagina();
        linkeo linker = new linkeo();

        protected void Page_Load(object sender, EventArgs e)
        {
            idds = Session["id_detalle_servicio"].ToString();
            

            if (idds.Equals("0"))
                Session["mensaje_error"] = "sin log";
            else
                Lidds.Text = linker.obtener_dato_especificado("select descripcion from detalle_servicio where id=" + idds, 0);

        }

        protected void add_Click(object sender, EventArgs e)
        {
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            id = this.Label2.Text;

            campos.Add("id_producto, ");
            campos.Add("cantidad, ");
            campos.Add("id_detalle_servicio");

            
            //colecciono datos
            datos.Add(id);
            datos.Add(",");
            datos.Add(this.cantidad.Text);
            datos.Add(",");
            datos.Add(idds);

            //pregunto si id es valido
            if ((rm = np.mensaje_marca(id)).Length < 1)
            {

                //agrego
                resultado = linker.insercion_de_dataset("producto_necesario", campos, datos);

                //verifico respuesta
                Labeltext.Text = resultado;
                string[] devolucion = new string[3];
                devolucion = linker.revisar_error(resultado, "INS", "Datos Cargados Correctamente", "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion", "abmservicios_agregar_producto_necesario.aspx", "abmservicios_agregar_producto_necesario.aspx");


                if (devolucion[0].Equals("0"))
                    Session["mensaje_error"] = devolucion[1];
                else
                    Session["mensaje_exito"] = devolucion[1];

                Response.Redirect(devolucion[2]);
            }
            else
                Response.Write(rm);

        }




        protected void dgvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[1].Text;
            this.Label2.Text = id;
        }



    }
}
