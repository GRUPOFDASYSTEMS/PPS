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
    public partial class modulo_servicios_creando_detalle_orden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string fecha2 = String.Format("{0:yyyyMMdd}", this.Calendar1.SelectedDate.ToShortDateString());
            Label2.Text = "Fecha Seleccionada: " + fecha2;
        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            linkeo linker = new linkeo();
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado, servicio, detalle_servicio, hs_necesarias, productos_necesarios;
            int id;
            //DateTime fecha = Convert.ToDatetime(this.Calendar1.SelectedDate.ToShortDateString());


            //que es lo que debo validar?
            //primero obtengo lo que me solicitan (en tiempo y cantidad de productos)
            servicio = this.DD_Servicio.SelectedValue;
            detalle_servicio = this.DDD_Servicio.SelectedValue;

            //cuanto tiempo? cantidad * hs del servicio
            hs_necesarias = linker.obtener_dato_especificado("select tiempo_horas_hombre from detalle_servicio where id="+detalle_servicio, 0);
            double hs = double.Parse(hs_necesarias) * Double.Parse (cantidad.Text) ;
            
            //productos_necesarios "select id_producto from productos necesarios where id_servicio="id


            //luego aseguro:
            //disponibilidad_recursos

            //disponibilidad_usuarios

            // finalmente deberia reservar stock
            //... y agregar la restriccion correspondiente al operario...


            string fecha = Calendar1.SelectedDate.ToString("yyyyMMdd");
            //especifico campos
            campos.Add("fecha, ");
            campos.Add("id_os, ");
            //verificar cual 
            campos.Add("id_servicio, ");
            // de los 2 eligio...
            campos.Add("id_detalle_servicio, ");


            campos.Add("cantidad, ");
            //el costo se obtiene por relacion de id_detalle_servicio (o id_servicio) * cantidad
            campos.Add("costo, ");
            campos.Add("comentario, ");
            //el tiempo se obtiene por relacion de id_detalle_servicio (o id_servicio) * cantidad
            campos.Add("tiempo ");

            //recolecto datos
            //datos.Add(" ' ");
            //datos.Add(fecha);
            //datos.Add(" ' ");
            //datos.Add(" , ");
            //datos.Add(" ' ");
            //datos.Add(Session["id_os"].ToString());//Session["id_os"]
            //datos.Add(" ' ");
            //datos.Add(" , ");
            //datos.Add(" ' ");
            //datos.Add(this.cantidad.Text);//tiempo
            //datos.Add(" ' ");
            //datos.Add(" , ");
            //datos.Add(" ' ");
            //datos.Add(this.comentario.Text);//des
            //datos.Add(" ' ");
            //datos.Add(" , ");
            //datos.Add(this.DropDownList1.SelectedValue);//idu


            //resultado = linker.insercion_de_dataset("restriccion_disponibilidad_usuario", campos, datos);
            //Label1.Text = resultado;

        }

        protected void RS_CheckedChanged(object sender, EventArgs e)
        {


            radios();

        }


        protected void RDS_CheckedChanged(object sender, EventArgs e)
        {
            radios();
        }



        protected void radios()
        {
            if (RS.Checked)
            {
                this.DDD_Servicio.Enabled = false;
                this.DD_Servicio.Enabled = true;
            }
            else
            {
                RDS.Checked = true;
                this.DDD_Servicio.Enabled = true;
                this.DD_Servicio.Enabled = false;
            }

        }

    }
}
