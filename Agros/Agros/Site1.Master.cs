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
    public partial class Site11 : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            /* SETEOS GENERALES*/ 
           // Label1.ForeColor = System.Drawing.Color.Red; //ver: no funciona para todas las paginas o hay que llamarlo distinto desde aca

            string mensaje_error = Session["mensaje_error"].ToString();
            if (mensaje_error.Length > 0)
            {
                //muestro alerta
                Response.Write(mensaje_error);
                Session["mensaje_error"] = "";
            }


            string mensaje_exito = Session["mensaje_exito"].ToString();
            if (mensaje_exito.Length > 0)
            {
                //muestro alerta
                Response.Write(mensaje_exito);
                Session["mensaje_exito"] = "";
            }

            
            
            //pagina p = new pagina();
            
            //verifica_login(); 
            //nueva_pagina np = new nueva_pagina();
            //np.verifica_login();
        }



        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnPreInit(e);
        //    // the following line is important
        //    MasterPage master = this.Master;
        //    // unfortunately, compiler warns us that master is not used
        //    ContentPageLabel.Text = "Hello, World!";
        //}




    }


    

    //interface  pagina
    //{

    //    void verifica_login();
        


    //}



    //public class paginas : pagina
    //{
    //    public void verifica_login()
    //    {
    //        if (Session["usuario"].Equals("0"))
    //            Response.Redirect("login.aspx");
    //    }
    //}







    public class nueva_pagina : Site11
    {

        linkeo linker = new linkeo();

        public string  mensaje_marca(string parametro)
        {
            string i = "<script>window.alert('";
            string f = "');</script>";
            string mensaje_error = "";
            bool res = true;

            if (parametro.Length < 1)
            {
                mensaje_error = "Debe Marcar Un Item Antes De Continuar";
                mensaje_error = i + mensaje_error + f;
                //Response.Write(mensaje_error);
                //res = false;
            }

            return mensaje_error;

        }




        public string generarFactura(string id_os, string id_cliente)
        {

            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado, id, estado, estado_buscado, detalle, precio, cantidad, select, error;
            int id_f;

            //verificacion del estado de la id seleccionada? (para evitar generar factura de algo ya aprobado... o abortada)
            id = " id=" + id_os;

            estado = linker.obtener_dato_especificado("select id_estado from orden_de_servicio where" + id, 0);
            // .obtener_dato("orden_de_servicio where "+id, 4);

            // solo la puedo aprobar si:
            //las Pre-Aprobada
            estado_buscado = linker.obtener_dato_especificado("select id from estados where descripcion='Pre-Aprobada' and tema='orden_servicio'", 0);

            if (!estado.Equals(estado_buscado))
            {
                error = "Error: solo puede Aprobar una orden Pre-Aprobada";

            }
            else
            {
                //Apruebo todas las ordenes hijas y tambien el estado de la orden general
                //primero las hijas
                id = " id_os=" + id_os;

                estado = linker.obtener_dato(" estados where descripcion='Aprobada' and tema='detalle_orden' ", 0);

                //especifico campos
                campos.Add("id_estado=");
                campos.Add(estado);

                resultado = linker.actualizacion_personalizada("detalle_orden_de_servicio", id, campos);


                //despues la orden
                campos.RemoveRange(0, campos.Count);
                id = " id=" + id_os;
                estado = linker.obtener_dato(" estados where descripcion='Aprobada' and tema='orden_servicio' ", 0);

                //especifico campos
                campos.Add("id_estado=");
                campos.Add(estado);

                resultado = linker.actualizacion_personalizada("orden_de_servicio", id, campos);





                //finalmente creo la factura asociada
                campos.RemoveRange(0, campos.Count);

                /********** generar cabecera inicial *************/
                campos.Add("fecha, ");
                campos.Add("id_os, ");
                campos.Add("id_estado, ");
                campos.Add("id_cliente");

                //fecha es hoy
                DateTime fecha = DateTime.Now;
                string fechas = fecha.ToString("yyyyMMdd");
                //id_os es id
                id = id_os;

                //el estado es siempre pendiente al inicio
                estado = linker.obtener_dato(" estados where descripcion='Pendiente' and tema='facturacion' ", 0);

                //y el cliente asociado
                //Session["cliente"].ToString(); &&lo escribo directamente...
                datos.Add(" ' ");
                datos.Add(fechas);
                datos.Add(" ' ");
                datos.Add(" , ");
                datos.Add(id);
                datos.Add(" , ");
                datos.Add(estado);
                datos.Add(" , ");
                datos.Add(id_cliente);//Session["cliente"].ToString()


                resultado = linker.insercion_de_dataset("facturas", campos, datos);


                /***** generar detalle a partir de cabecera ****/
                campos.RemoveRange(0, campos.Count);
                datos.RemoveRange(0, datos.Count);

                //para generar todos los detalles debera ser un bucle de todos los detalle_orden_de_servicio

                //genero consulta previa antes de cambiar de id
                select = "(select ds.descripcion from detalle_servicio ds, detalle_orden_de_servicio dos where dos.id_detalle_servicio=ds.id and dos.id_os=" + id + ")x";
                //id_factura
                id_f = linker.obtener_id("facturas");

                //detalle (segun detalle_servicio asociado a detalle_orden_de_servicio)
                //esto funciona para un solo caso... pero hay que hacer un bucle para todos
                //DEVOLVER UN ARRAY O UN DATASET... Y EOF()
                detalle = linker.obtener_dato(select, 0);

                //monto_unitario
                //QUIZA EL ES MISMO DATA SET DADO QUE... OJO EL ID QUE USAMOS!!
                select = "(select dos.costo from detalle_servicio ds, detalle_orden_de_servicio dos where dos.id_detalle_servicio=ds.id and dos.id_os=" + id_os + ")x";
                precio = linker.obtener_dato(select, 0);  //tambien se puede obtener de dos.costo

                //cantidad
                select = "(select dos.cantidad from detalle_servicio ds, detalle_orden_de_servicio dos where dos.id_detalle_servicio=ds.id and dos.id_os=" + id_os + ")x";
                cantidad = linker.obtener_dato(select, 0);  //


                /* el ultimo campo se autocalcula */

                /* crear instruccion de creacion de detalle... y  */
                campos.Add("id_factura, ");
                campos.Add("detalle, ");
                campos.Add("monto_unitario, ");
                campos.Add("cantidad");


                datos.Add(id_f);
                datos.Add(" , ");
                datos.Add(" ' ");
                datos.Add(detalle);
                datos.Add(" ' ");
                datos.Add(" , ");
                datos.Add(precio);
                datos.Add(" , ");
                datos.Add(cantidad);

                resultado = linker.insercion_de_dataset("detalle_de_facturas", campos, datos);


                /******** ... y por ultimo generar ultimos datos de cabecera ********/
                campos.RemoveRange(0, campos.Count);
                datos.RemoveRange(0, datos.Count);


                // neto y total actualizar cabecera de factura segun el detalle generado
                //tipo, iva e iibb se recuperan segun el cliente... por ahora lo dejamos con datos predeterminados
                //tipo.. es la letra, por ahora siempre A
                campos.Add("tipo= 'A', ");
                //iva, por ahora siempre 21%, ojo, aca va en valores
                //PRIMERO CALCULAMOS EL TOTAL
                string total = linker.obtener_dato_especificado("select sum(monto_final) from detalle_de_facturas where id_factura=" + id_f, 0);
                double totali = Double.Parse(total);

                //SEGUNDO CALCULAMOS EL IVA DEL TOTAL
                double Iva = totali - (totali / 1.21);

                //TERCERO IIBB
                double Iibb = totali - (totali / 1.035);

                //FINALMENTE OBTENEMOS EL NETO FINAL
                double Neto = totali - Iva - Iibb;

                //string iva= Iva.ToString().Substring(0,Iva.ToString().IndexOf(",")+2); &&Falla en los redondos...
                string iva = Iva.ToString().Replace(",", ".");

                //string iibb = Iibb.ToString().Substring(0, Iibb.ToString().IndexOf(",") + 2);
                string iibb = Iibb.ToString().Replace(",", ".");


                //string neto = Neto.ToString().Substring(0, Neto.ToString().IndexOf(",") + 2);
                string neto = Neto.ToString().Replace(",", ".");


                //total = totali.ToString().Substring(0, totali.ToString().IndexOf(",") + 2);
                total = totali.ToString().Replace(",", ".");


                campos.Add("iva= ");
                datos.Add(" ' ");
                campos.Add(iva);
                datos.Add(" ' ");
                campos.Add(" , ");
                campos.Add("iibb= ");
                datos.Add(" ' ");
                campos.Add(iibb);
                datos.Add(" ' ");
                campos.Add(" , ");
                campos.Add("neto= ");
                datos.Add(" ' ");
                campos.Add(neto);
                datos.Add(" ' ");
                campos.Add(" , ");
                campos.Add("total= ");
                datos.Add(" ' ");
                campos.Add(total);
                datos.Add(" ' ");
                campos.Add("  ");




                resultado = linker.actualizacion_personalizada("facturas", "id=" + id_f, campos);
                error = verificarOperacion(resultado, "UPD") ? "Generacion de factura exitosa" : "Error: Ha ocurrido un error al intentar generar la factura";

            }

            return error;

        }



        public string obtenerEstados(string tabla, string id_a_consultar, string estado_permitido, string tema_asociado)
        {

            string estado = linker.obtener_dato_especificado("select id_estado from "+tabla+" where id=" + id_a_consultar, 0);
            string error = "";

            if (estado == "-1")
                return "No existe el id buscado";
            
            
            // solo la puedo aprobar si:
            string estado_buscado = linker.obtener_dato_especificado("select id from estados where descripcion='" + estado_permitido + "' and tema='" + tema_asociado + "'", 0);

            if (estado_buscado == "-1")
                return "No existe el estado buscado";



            if (!estado.Equals(estado_buscado))
            {
                error = "Error: los estados no coinciden";

            }
            else
                error = "OK";

            
            return error;
        
        }








        public bool verificarOperacion(string resultado, string ope)
        {

            //verifico respuesta
            bool res = true;
            string[] devolucion = new string[3];
            devolucion = linker.revisar_error(resultado, ope, "", "", "", "");




            if (devolucion[0].Equals("0"))
            {
                //Session["mensaje_error"] = devolucion[1];
                //LabelInfo.ForeColor = System.Drawing.Color.Red;
                //LabelInfo.Text = mensaje;
                
                res = false;
            }

            return res;

        }


        public virtual void verifica_login()
        {

            // if (!this.Label1.Text.Equals("~"))

            ContentPlaceHolder mpContentPlaceHolder;
            TextBox mpTextBox;
            mpContentPlaceHolder =
              (ContentPlaceHolder)Master.FindControl("Content1");
            if (mpContentPlaceHolder != null)
            {
                mpTextBox =
                    (TextBox)mpContentPlaceHolder.FindControl("TextBoxLogin");
                if (mpTextBox != null)
                {
                    // mpTextBox.Text = "TextBox found!";
                }
                else
                {

                    if (Session["usuario"].Equals("0"))
                        Response.Redirect("login.aspx");

                }



            }






        }



    }








}


 

