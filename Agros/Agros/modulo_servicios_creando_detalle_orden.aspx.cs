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
        string resultado, servicio, detalle_servicio, hs_necesarias, productos_necesarios, operario_disponible, consulta_especificada, fecha_hoy;
        int id, hs_totales ;
        

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
            string cant = cantidad.Valor;
            string cm = comentario.Text;
            string ope = DD_Operario.SelectedValue;

            if ((Label2.Text.Length > 0) && (cant.Length >0))
            {


                /**** primero obtengo lo que me solicitan (en tiempo y cantidad de productos) ****/
                string fecha = Calendar1.SelectedDate.ToString("yyyyMMdd");
                //DateTime fecha_seleccionada = DateTime(Calendar1.SelectedDate);
                DateTime fecha_inicio = Convert.ToDateTime(this.Calendar1.SelectedDate.ToShortDateString());
                DateTime hora_inicio = fecha_inicio.AddHours(8); //establezco las 8 am
                //servicio = this.DD_Servicio.SelectedValue;
                servicio = "";
                detalle_servicio = this.DDD_Servicio.SelectedValue;
                //solo vale uno de los dos...
                //if (RS.Checked)
                //    detalle_servicio = "";  //OJO QUE SI LIMPIAMOS ACA, LUEGO TENEMOS QUE DARLE UN VALOR PARA EJECUTAR LA CONSULTA...
                //else
                //    servicio = "";






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
                hs_totales = int.Parse(hs_necesarias) * int.Parse(cant);


                //finalmente si hs_totales > 8 entonces corresponden x dias   --ejemplo 16, seran 2 dias---
                int dias_ocupados = hs_totales / 8;
                int diferencia = hs_totales % 8;
                DateTime fecha_fin = fecha_inicio.AddDays(dias_ocupados); //adiciono cantidad dias
                DateTime hora_fin = fecha_fin.AddHours(8); //establezco las 8 am u 8 hs diarias
                hora_fin = diferencia > 0 ? hora_fin.AddHours(diferencia) : hora_fin.AddHours(-16);//agrego la diferencia o establezco el fin del dia anterior

                //formateo las fechas para consultar
                string fecha1 = hora_inicio.ToString("yyyyMMdd");
                string fecha2 = hora_fin.ToString("yyyyMMdd");
                /**** ahora ya tengo la cantidad de tiempo que me va a llevar a partir de fecha (hora_inicio) hasta (hora_fin) ***/
                //entonces tengo que ver si esos dias el operacio ope esta disponible
                consulta_especificada = "select id from restriccion_disponibilidad_usuario " +
                                        " where  ( " +
                                                    " (id_usuario=" + ope + ")" +
                                                    " and " +
                                                    " (  " +
                                                            "( '" + fecha1 + "' between fecha_inicio and fecha_fin )" +
                                                            " or " +
                                                            "( '" + fecha2 + "' between fecha_inicio and fecha_fin )" +
                                                            " or " +
                                                            "( fecha_inicio > '" + fecha1 + "' and fecha_fin <= '" + fecha2 + "')" +

                                                    " )  " +
                                                " )  ";



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
                    //Si brindamos una opcion
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
                     * 
                     * 
                     */


                    /* Primero vemos que productos hacen falta*/
                    DataSet PN = new DataSet();
                    PN = linker.Seleccion_en_dataset("select * from producto_necesario where id_detalle_servicio=" + detalle_servicio);


                    // Luego el stock de cada uno 
                    bool stock_suficiente = true;

                    foreach (DataRow row in PN.Tables[0].Rows)
                    {

                        string prod = row["id_producto"].ToString();
                        string cant_prod = row["cantidad"].ToString();
                        int total_racion_necesaria = int.Parse(cant_prod) * int.Parse(cant);


                        /* Aca tenemos 2 situaciones*/
                        //si no hay reservas... se toma el stock directo
                        int lqt = int.Parse(linker.obtener_dato_especificado("SELECT r.en_cantidad_unidades AS 'StockDisponible' FROM  reservas_stock AS r where r.id_producto=" + prod, 0));
                        //Pero si existen reservas, Es el stock real (el que esta menos el reservado...)
                        lqt = lqt == -1 ? int.Parse(linker.obtener_dato_especificado("SELECT s.cantidad AS 'StockDisponible' FROM stock AS s where s.id_producto=" + prod, 0)) : int.Parse(linker.obtener_dato_especificado("SELECT s.cantidad - r.en_cantidad_unidades AS 'StockDisponible' FROM stock AS s, reservas_stock AS r where s.id_producto = r.id_producto  and s.id_producto=" + prod, 0));
                        //int lqt = int.Parse(linker.obtener_dato_especificado("SELECT s.cantidad - r.en_cantidad_unidades AS 'StockDisponible' FROM stock AS s, reservas_stock AS r where s.id_producto = r.id_producto  and s.id_producto=" + prod, 0));

                        int lqt_enracion = int.Parse(linker.obtener_dato_especificado("select racion_unidad_medida from productos where id=" + prod, 0)) * lqt;

                        //  si alguno falla es false para todos...
                        if (total_racion_necesaria > lqt_enracion)
                            stock_suficiente = false;
                    }





                    if (!stock_suficiente)
                    {
                        /*      NOWAY ... INFORMAR QUE DEBERIA SELECCIONAR MENOS HECTAREAS...*/
                        LabelInfo.ForeColor = System.Drawing.Color.Red;
                        LabelInfo.Text = "No existe stock suficiente para el pedido solicitado. Puede optar con disminuir la cantidad de hectareas, o seleccionar otro servicio, y reintente nuevamente.";
                    }
                    else
                    {
                        /*      OK, CONTINUAR Y AGREGAR LA RESERVA OK... YA SE COMPLETARON TODOS LOS FILTROS!!!! */


                        /*HAAAAP PERO HABRIA QUE VALIDAR SI LA ID_OS ESTA EN ESTADO DE PROCESO (UNICO ESTADO POSIBLE DE ADICION DE DETALLES)*/
                        string creando = linker.obtener_dato_especificado("select id from estados where descripcion='En Proceso de creacion' and tema='orden_servicio' ", 0);
                        string estado = linker.obtener_dato_especificado("select id_estado from orden_de_servicio where id=" + Session["id_os"].ToString(), 0);


                        if (creando.Equals(estado))
                        {



                            /*1) Inserto la orden de servicio.*/
                            //obtengo datos
                            DateTime hoy = DateTime.Now; //establezco la fecha actual

                            //formateo las fechas para consultar
                            fecha_hoy = hoy.ToString("yyyyMMdd");

                            //el costo se obtiene por relacion de id_detalle_servicio (o id_servicio) * cantidad
                            double costo = double.Parse(linker.obtener_dato_especificado("select precio from detalle_servicio where id=" + detalle_servicio, 0)) * int.Parse(cant);




                            //el tiempo se obtiene por relacion de id_detalle_servicio (o id_servicio) * cantidad

                            //especifico campos
                            campos.Add("fecha, ");
                            campos.Add("id_os, ");
                            //verificar cual 
                            campos.Add("id_servicio, ");
                            // de los 2 eligio...
                            campos.Add("id_detalle_servicio, ");
                            campos.Add("cantidad, ");
                            campos.Add("costo, ");
                            campos.Add("comentario, ");
                            campos.Add("fecha_inicio, ");
                            campos.Add("fecha_fin ");

                            //recolecto datos
                            datos.Add(" ' ");
                            datos.Add(fecha_hoy);
                            datos.Add(" ' ");
                            datos.Add(" , ");
                            datos.Add(" ' ");
                            datos.Add(Session["id_os"].ToString());//Session["id_os"]
                            datos.Add(" ' ");
                            datos.Add(" , ");
                            datos.Add(" ' ");
                            datos.Add(servicio); //ojo cuando limpio las variables
                            datos.Add(" ' ");
                            datos.Add(" , ");
                            datos.Add(" ' ");
                            datos.Add(detalle_servicio);
                            datos.Add(" ' ");
                            datos.Add(" , ");
                            datos.Add(cant);//cantidad de hectareas
                            datos.Add(" , ");
                            datos.Add(" ' ");
                            datos.Add(costo);//costo es double
                            datos.Add(" ' ");
                            datos.Add(" , ");
                            datos.Add(" ' ");
                            datos.Add(cm);//com
                            datos.Add(" ' ");
                            datos.Add(" , ");
                            datos.Add(" ' ");
                            datos.Add(hora_inicio.ToString("yyyyMMdd"));//tiempo
                            datos.Add(" ' ");
                            datos.Add(" , ");
                            datos.Add(" ' ");
                            datos.Add(hora_fin.ToString("yyyyMMdd"));//tiempo
                            datos.Add(" ' ");


                            resultado = linker.insercion_de_dataset("detalle_orden_de_servicio", campos, datos);



                            //verifico respuesta
                            if (verificarInsercion(resultado, "Atencion Ocurrio Un Error Al Intentar Ingresar El Item Actual En La Orden De Servicio"))
                            {

                                /* ahora debo actualizar el costo de la orden de servicio asociada */
                                datos.RemoveRange(0, datos.Count);

                                string costo_actual = linker.obtener_dato_especificado("select costo_total from orden_de_servicio where id=" + Session["id_os"].ToString(), 0);
                                costo_actual = costo_actual == "" ? "0" : costo_actual;
                                double costo_total = double.Parse(costo_actual) + costo;
                                datos.Add("costo_total=");
                                datos.Add(costo_total);

                                resultado = linker.actualizacion_personalizada("orden_de_servicio", " id=" + Session["id_os"].ToString(), datos);
                                //si existe un error, en esta instancia, no paro dado que quiza este error no es critico...
                                verificarActualizacion(resultado, "Atencion Ocurrio Un Error Al Intentar Actualizar La Orden De Servicio");



                                /* finalmente deberia reservar stock... */
                                /* Ojo que es para todos los productos involucrados */

                                bool verif_inp = true;

                                foreach (DataRow row in PN.Tables[0].Rows)
                                {

                                    string prod = row["id_producto"].ToString();
                                    string cant_prod = row["cantidad"].ToString();
                                    int total_racion_necesaria = int.Parse(cant_prod) * int.Parse(cant);
                                    double lqt_enracion = total_racion_necesaria / int.Parse(linker.obtener_dato_especificado("select racion_unidad_medida from productos where id=" + prod, 0));
                                    int en_cantidad_unidades = (int)Math.Floor(lqt_enracion);

                                    campos.RemoveRange(0, campos.Count);
                                    datos.RemoveRange(0, datos.Count);

                                    campos.Add("fecha, ");
                                    campos.Add("racion_unidad_medida, ");
                                    campos.Add("id_estado, ");
                                    campos.Add("id_producto, ");
                                    campos.Add("en_cantidad_unidades");

                                    datos.Add(" ' ");
                                    datos.Add(fecha_hoy);
                                    datos.Add(" ' ");
                                    datos.Add(" , ");
                                    datos.Add(total_racion_necesaria);
                                    datos.Add(" , ");
                                    datos.Add(" 1 ");
                                    datos.Add(" , ");
                                    datos.Add(" ' ");
                                    datos.Add(prod);
                                    datos.Add(" ' ");
                                    datos.Add(" , ");
                                    datos.Add(en_cantidad_unidades);//en_cantidad_unidades



                                    resultado = linker.insercion_de_dataset("reservas_stock", campos, datos);


                                    //  si alguno falla es false para todos...
                                    if (!verificarInsercion(resultado, "Atencion! ocurrieron errores en la reserva de stock")) //se podria poner en otro label...
                                        verif_inp = false;
                                }



                                /* y agregar la restriccion correspondiente al operario... */
                                string descripcion = "detalle de orden de servicio asociado N°:" + linker.obtener_id("detalle_orden_de_servicio");

                                campos.RemoveRange(0, campos.Count);
                                datos.RemoveRange(0, datos.Count);

                                campos.Add("fecha_registracion, ");
                                campos.Add("id_usuario, ");
                                campos.Add("fecha_inicio, ");
                                campos.Add("fecha_fin, ");
                                campos.Add("descripcion ");

                                datos.Add(" ' ");
                                datos.Add(fecha_hoy);
                                datos.Add(" ' ");
                                datos.Add(" , ");
                                datos.Add(ope);
                                datos.Add(" , ");
                                datos.Add(" ' ");
                                datos.Add(hora_inicio.ToString("yyyyMMdd"));
                                datos.Add(" ' ");
                                datos.Add(" , ");
                                datos.Add(" ' ");
                                datos.Add(hora_fin.ToString("yyyyMMdd"));
                                datos.Add(" ' ");
                                datos.Add(" , ");
                                datos.Add(" ' ");
                                datos.Add(descripcion);//descripcion
                                datos.Add(" ' ");

                                resultado = linker.insercion_de_dataset("restriccion_disponibilidad_usuario", campos, datos);
                                if (!verificarInsercion(resultado, "Atencion! ocurrieron errores en la reserva de horas del personal")) //se podria poner en otro label...
                                    verif_inp = false;

                                /* debo asignar a su id de usuario... */
                                campos.RemoveRange(0, campos.Count);
                                datos.RemoveRange(0, datos.Count);

                                datos.Add("id_usuario=");
                                datos.Add(ope);

                                //obtengo id de detalle servicio
                                id = linker.obtener_id("detalle_orden_de_servicio");

                                resultado = linker.actualizacion_de_dataset("detalle_orden_de_servicio", id.ToString(), datos);

                                //  si alguno falla es false para todos...
                                if (!verificarActualizacion(resultado, "Atencion! ocurrieron errores en la reserva de horas del personal")) //se podria poner en otro label...
                                    verif_inp = false;



                                LabelGeneral.ForeColor = System.Drawing.Color.Green;
                                LabelGeneral.Text = "Orden de servicio generada correctamente. Puede continuar generando ordenes o finalizar desde el boton FINALIZAR EDICION.                 Si existieron errores o advertencias, se muestran a continuacion.";

                            }

                        }
                        else
                        {

                            LabelGeneral.ForeColor = System.Drawing.Color.Red;
                            LabelGeneral.Text = "No se permite agregar items a una Orden de servicio ya gestionada.";

                        }


                    }
                }

                //deshabilito para evitar errores
                agregar.Enabled = false;
            }
            else
            {
                LabelGeneral.Text = "Debe seleccionar una fecha, e indicar la cantidad de hectareas antes de continuar.";
            }

        }





        protected bool verificarInsercion(string resultado, string mensaje) {

            //verifico respuesta
            bool res = true;
            string[] devolucion = new string[3];
            devolucion = linker.revisar_error(resultado, "INS", "", "", "", "");




            if (devolucion[0].Equals("0"))
            {
                //Session["mensaje_error"] = devolucion[1];
                LabelInfo.ForeColor = System.Drawing.Color.Red;
                LabelInfo.Text = mensaje;
                res = false;
            }

            return res;
        
        }


        protected bool verificarActualizacion(string resultado, string mensaje)
        {

            //verifico respuesta
            bool res = true;
            string[] devolucion = new string[3];
            devolucion = linker.revisar_error(resultado, "UPD", "", "", "", "");




            if (devolucion[0].Equals("0"))
            {
                //Session["mensaje_error"] = devolucion[1];
                LabelInfo.ForeColor = System.Drawing.Color.Red;
                LabelInfo.Text = mensaje;
                res = false;
            }

            return res;
        
        }
        

        protected void RS_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RDS_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void new_Click(object sender, EventArgs e)
        {
            Response.Redirect("modulo_servicios_creando_detalle_orden.aspx");
        }




//        protected void RS_IsChecked(object sender, EventArgs e) {
//            this.DDD_Servicio.Enabled = false;
//            this.DD_Servicio.Enabled = true;

//        }

//        protected void RS_CheckedChanged(object sender, EventArgs e)
//        {


//            //radios();
////                    this.DDD_Servicio.Enabled = false;
//  //                  this.DD_Servicio.Enabled = true;


//        }


//        protected void RDS_CheckedChanged(object sender, EventArgs e)
//        {
//            //radios();

//                    this.DDD_Servicio.Enabled = true;
//                    this.DD_Servicio.Enabled = false;

//        }



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
