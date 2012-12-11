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
        linkeo linker = new linkeo();
        string resultado, servicio, detalle_servicio, hs_necesarias, productos_necesarios;
        int id;

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
            
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();

            //DateTime fecha = Convert.ToDatetime(this.Calendar1.SelectedDate.ToShortDateString());
            


            /**** primero obtengo lo que me solicitan (en tiempo y cantidad de productos) ****/
            string fecha = Calendar1.SelectedDate.ToString("yyyyMMdd");
            //DateTime fecha_seleccionada = DateTime(Calendar1.SelectedDate);
            DateTime fecha_inicio = Convert.ToDateTime(this.Calendar1.SelectedDate.ToShortDateString());
            servicio = this.DD_Servicio.SelectedValue;
            detalle_servicio = this.DDD_Servicio.SelectedValue;
            //solo vale uno de los dos...
            if (RS.Checked)
                detalle_servicio = "";
            else
                servicio = "";
            string cant = cantidad.Text;
            string cm = comentario.Text;
            string ope = DD_Operario.SelectedValue;



            /*** Que es lo que debo validar?  ****/
            /*si tengo suficientes recursos*/
            /*1) tiempo     - relacionado con los operarios favoritos (restriccion_disponibilidad_usuario)*/
            /*2) productos  - relacionado con el stock disponible (stock real-reservado) */
                //cuanto tiempo? cantidad * hs del servicio... pero...
                /*tenemos 2 instancias*/
                /* primero la mas simple, si elige un detalle servicio */
                hs_necesarias = linker.obtener_dato_especificado("select tiempo_horas_hombre from detalle_servicio where id=" + detalle_servicio, 0);
            //primero solo tomo las horas (no los minutos.... ya fue)
                hs_necesarias = hs_necesarias.Substring(0, 2);
            //ahora debo ver como multiplicar...
                int hs_totales = int.Parse(hs_necesarias) * int.Parse(cant);

            //double hs_totales = double.Parse(hs_necesarias) * double.Parse (cantidad.Text) ;
             //finalmente si hs_totales > 8 entonces corresponden x dias   --ejemplo 16, seran 2 dias---
                int dias_ocupados = hs_totales / 8;
                int diferencia = hs_totales % 8;
                DateTime  fecha_fin =fecha_inicio.AddDays(dias_ocupados); //adiciono cantidad dias
                DateTime hora_fin = fecha_fin.AddHours(8); //establezco las 8 am u 8 hs diarias
                hora_fin = diferencia > 0 ? hora_fin.AddHours(diferencia) : hora_fin.AddHours(-16);//agrego la diferencia o establezco el fin del dia anterior


                //fecha_seleccionada2 = fecha_seleccionada2.AddDays(dias_ocupados);
                //fecha_seleccionada2= fecha_seleccionada2.AddHours(hs_totales);
            //ahora tengo la cantidad de tiempo que me va a llevar a partir de fecha 
            //entonces tengo que ver si esos dias el operacio ope esta disponible
            
            //productos_necesarios "select id_producto from productos necesarios where id_servicio="id


            //luego aseguro:
            //disponibilidad_recursos

            //disponibilidad_usuarios

            // finalmente deberia reservar stock
            //... y agregar la restriccion correspondiente al operario...


            
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




        protected void RS_IsChecked(object sender, EventArgs e) {
            this.DDD_Servicio.Enabled = false;
            this.DD_Servicio.Enabled = true;

        }

        protected void RS_CheckedChanged(object sender, EventArgs e)
        {


            //radios();
//                    this.DDD_Servicio.Enabled = false;
  //                  this.DD_Servicio.Enabled = true;


        }


        protected void RDS_CheckedChanged(object sender, EventArgs e)
        {
            //radios();

                    this.DDD_Servicio.Enabled = true;
                    this.DD_Servicio.Enabled = false;

        }



        //protected void radios()
        //{
        //    if (RS.Checked)
        //    {
        //        this.DDD_Servicio.Enabled = false;
        //        this.DD_Servicio.Enabled = true;
        //    }
        //    else
        //    {
        //        RDS.Checked = true;
        //        this.DDD_Servicio.Enabled = true;
        //        this.DD_Servicio.Enabled = false;
        //    }

        //}

    }
}
