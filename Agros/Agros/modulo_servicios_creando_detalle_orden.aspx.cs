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
        string resultado, servicio, detalle_servicio, hs_necesarias, productos_necesarios, operario_disponible, consulta_especificada;
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

            /*Primero hay que asegurarse que todos los valores esten elegidos...
             se puede hacer con validators o desde el codigo...*/
            


            /**** primero obtengo lo que me solicitan (en tiempo y cantidad de productos) ****/
            string fecha = Calendar1.SelectedDate.ToString("yyyyMMdd");
            //DateTime fecha_seleccionada = DateTime(Calendar1.SelectedDate);
            DateTime fecha_inicio = Convert.ToDateTime(this.Calendar1.SelectedDate.ToShortDateString());
            DateTime hora_inicio = fecha_inicio.AddHours(8); //establezco las 8 am
            servicio = this.DD_Servicio.SelectedValue;
            detalle_servicio = this.DDD_Servicio.SelectedValue;
            //solo vale uno de los dos...
            if (RS.Checked)
                detalle_servicio = "";  //OJO QUE SI LIMPIAMOS ACA, LUEGO TENEMOS QUE DARLE UN VALOR PARA EJECUTAR LA CONSULTA...
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

            
             //finalmente si hs_totales > 8 entonces corresponden x dias   --ejemplo 16, seran 2 dias---
                int dias_ocupados = hs_totales / 8;
                int diferencia = hs_totales % 8;
                DateTime  fecha_fin =fecha_inicio.AddDays(dias_ocupados); //adiciono cantidad dias
                DateTime hora_fin = fecha_fin.AddHours(8); //establezco las 8 am u 8 hs diarias
                hora_fin = diferencia > 0 ? hora_fin.AddHours(diferencia) : hora_fin.AddHours(-16);//agrego la diferencia o establezco el fin del dia anterior

                //formateo las fechas para consultar
                //string fecha1 = String.Format("{0:yyyyMMdd}", hora_inicio.ToShortDateString());
                //string fecha2 = String.Format("{0:yyyyMMdd}", hora_fin.ToShortDateString());
                string fecha1 = hora_inicio.ToString("yyyyMMdd");
                string fecha2 = hora_fin.ToString("yyyyMMdd");
            /**** ahora ya tengo la cantidad de tiempo que me va a llevar a partir de fecha (hora_inicio) hasta (hora_fin) ***/
                        //entonces tengo que ver si esos dias el operacio ope esta disponible
            /* EJEMPLO...
             * SELECT        id
               FROM            restriccion_disponibilidad_usuario
                WHERE        (id_usuario = 5) and ((fecha_inicial BETWEEN '02/11/2012' AND '03/11/2012') OR
                (fecha_final BETWEEN '04/11/2012' AND '04/11/2012'))
             */
                consulta_especificada = "select id from restriccion_disponibilidad_usuario "+
                                        " where  ( "+   
                                                    " (id_usuario=" + ope + ")"+
                                                    " and "+
                                                    " (  "+
                                                            "( '" + fecha1 + "' between fecha_inicio and fecha_fin )" +
                                                            " or "+
                                                            "( '" + fecha2 + "' between fecha_inicio and fecha_fin )" +
                                                            " or " +
                                                            "( fecha_inicio > '" + fecha1 + "' and fecha_fin <= '" + fecha2 + "')" +

                                                    " )  "+
                                                " )  ";


                                                //    "   (fecha_inicio between '" + fecha1 + "' and '" + fecha2 + "') or (fecha_fin between  '" + fecha1 + "' and '" + fecha2 + "')) and ;
                operario_disponible = linker.obtener_dato_especificado(consulta_especificada, 0);
            /* Si existe algun registro entonces debo informar y brindar una opcion o que el mismo elija otro..*/
                if (!operario_disponible.Equals("-1")) //ojo con los errores...
                { /*ojo con los errores... si existe un error por ejemplo servidor caido nos devuelve el error
                   * entonces entra aca, para salvar esa situacion preguntamos por el length. en general si nos 
                   * devuelve un id no seran mas de 9 caracteres ###,###,###... un error tiene mas de 10*/
                    LabelInfo.ForeColor = System.Drawing.Color.Red;
                    if (operario_disponible.Length > 9)
                        LabelInfo.Text = "Ha Ocurrido un error al intentar ejecutar la consulta.";
                    else
                        LabelInfo.Text = "No existen horarios disponibles para el operario elegido. Puede optar por cambiar de fecha, de operario, o disminuir la cantidad de hectareas, y reintente nuevamente.";
                    //si brindamos una opcion
                    //deberia hacer un while con el id de todos los usuarios y al encontrar uno informarlo...
                    //si hay tiempo lo hago, por ahora solo informo que no hay tiempo con ese operario, y que debe cambiar de operario o de dia.
                    //quiza la recomendacion mejor seria brindarle la primer fecha disponible con el operario elegido... haciendo fecha +1 fecha +2..no se un lio igual

                }
                else   //OK, CONTINUAR..            
                {


                    /* FINALMENTE  aseguro:
                    //disponibilidad_recursos
                     * ACA HAY 2 SALIDAS:
                     * 1) Directo: implica directamente al servicio elegido (se eligio un detalle)
                     * id_servicio= detalle_servicio
                     * 2) Indirecto: se debe hacer un bucle para todos los detalle_servicio implicados en el servicio elegido...
                     * QUIZA EL MODO INDIRECTO LO DEJEMOS DE LADO. PRIMERO HAGAMOS CON EL DIRECTO DESPUES VEMOS SI HAY TIEMPO...
                     * DE CUALQUIER MODO, LO QUE TENEMOS QUE ASEGURAR ES EL STOCK...
                     * WHILE PARA TODOS LOS PRODUCTOS...
                    Primero vemos que productos hacen falta
                     * //quiza un array de string[] productos_necesarios "select id_producto from productos necesarios where id_servicio="id
                     Luego el stock de cada uno 
                    //stock_neto select cantidad-racion_unidad_medida as neto from stock where id_producto=p.id_producto and s.id_producto=p.id_producto...
                     * if stock_neto<cantidad_necesaria
                     *      NOWAY ... INFORMAR QUE DEBERIA SELECCIONAR MENOS HECTAREAS...
                     * else     
*                       OK, CONTINUAR Y AGREGAR LA RESERVA OK... YA SE COMPLETARON TODOS LOS FILTROS!!!!
                     * 
                     * 
                     */





                    // finalmente deberia reservar stock
                    //... y agregar la restriccion correspondiente al operario...

                    LabelInfo.ForeColor = System.Drawing.Color.Green;
                    LabelInfo.Text = "Orden de servicio generada correctamente. Puede continuar generando ordenes o finalizar desde el boton FINALIZAR EDICION.";
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
