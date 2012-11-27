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
    public partial class modulo_servicios_cliente_listados : System.Web.UI.Page
    {

        linkeo linker = new linkeo();

        protected void Page_Load(object sender, EventArgs e)
        {


            Label1.Text = Session["cliente"].ToString();


        }




        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label2.Text = "";
            lerror.Text = "";
        }

        protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado, id, estado, estado_buscado, detalle, precio, cantidad, select;
            int id_f;

            //verificacion del estado de la id seleccionada? (para evitar generar factura de algo ya aprobado... o abortada)
            id = " id=" + Label2.Text;

            estado = linker.obtener_dato_especificado("select id_estado from orden_de_servicio where" + id, 0);
            // .obtener_dato("orden_de_servicio where "+id, 4);

            // solo la puedo aprobar si:
            //las Pre-Aprobada
            estado_buscado = linker.obtener_dato_especificado("select id_estado from estado where descripcion='Pre-Aprobada' and tema='orden_servicio'" + id, 0);

            if (!estado.Equals(estado_buscado))
            {
                lerror.Text = "Error: solo puede Aprobar una orden Pre-Aprobada";

            }
            else
            {
                //Apruebo todas las ordenes hijas y tambien el estado de la orden general
                //primero las hijas


                id = " id_os=" + Label2.Text;

                estado = linker.obtener_dato(" estados where descripcion='Aprobada' and tema='detalle_orden' ", 0);

                //especifico campos
                campos.Add("id_estado=");
                campos.Add(estado);

                resultado = linker.actualizacion_personalizada("detalle_orden_de_servicio", id, campos);


                //despues la orden
                campos.RemoveRange(0, campos.Count);
                id = " id=" + Label2.Text;
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
                id = Label2.Text;

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
                datos.Add(Session["cliente"].ToString());


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
                select = "(select dos.costo from detalle_servicio ds, detalle_orden_de_servicio dos where dos.id_detalle_servicio=ds.id and dos.id_os=" + Label2.Text + ")x";
                precio = linker.obtener_dato(select, 0);  //tambien se puede obtener de dos.costo

                //cantidad
                select = "(select dos.cantidad from detalle_servicio ds, detalle_orden_de_servicio dos where dos.id_detalle_servicio=ds.id and dos.id_os=" + Label2.Text + ")x";
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
                Label2.Text = resultado;
            }
        }




        protected void dgvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[1].Text;
            Label2.Text = id;
            lerror.Text = "";
        }








        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            //PostBackUrl="~/modulo_servicios_listado_detalle_orden.aspx"
            Session["id_os"] = Label2.Text;
            Response.Redirect("modulo_servicios_listado_detalle_orden.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado, id, estado, estado_buscado;
            int id_f;




            id = " id=" + Label2.Text;

            estado = linker.obtener_dato_especificado("select id_estado from orden_de_servicio where" + id, 0);
            // .obtener_dato("orden_de_servicio where "+id, 4);

            // solo la puedo abortar si:
            //las Pendiente
            estado_buscado = linker.obtener_dato_especificado("select id_estado from estado where descripcion='Pendiente' and tema='orden_servicio'" + id, 0);

            if (!estado.Equals(estado_buscado))
            {
                lerror.Text = "Error: solo puede Abortar una orden Pendiente";

            }
            else
            {


                //aborto
                //primero las hijas
                id = " id_os=" + Label2.Text;
                //las pongo como no aprobada
                estado = linker.obtener_dato(" estados where descripcion='No Aprobada' and tema='detalle_orden' ", 0);

                //especifico campos
                campos.Add("id_estado=");
                campos.Add(estado);

                resultado = linker.actualizacion_personalizada("detalle_orden_de_servicio", id, campos);








                //despues la orden
                id = " id=" + Label2.Text;

                estado = linker.obtener_dato(" estados where descripcion='Abortada' and tema='orden_servicio' ", 0);

                //especifico campos
                campos.Add("id_estado=");
                campos.Add(estado);

                resultado = linker.actualizacion_personalizada("orden_de_servicio", id, campos);

            }

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            ArrayList campos = new ArrayList();
            string id, estado, resultado, estado_buscado;




            //verificacion del estado de la id seleccionada? (para evitar generar factura de algo ya aprobado... o abortada)
            id = " id=" + Label2.Text;

            estado = linker.obtener_dato_especificado("select id_estado from orden_de_servicio where" + id, 0);
            // .obtener_dato("orden_de_servicio where "+id, 4);

            // solo la puedo aprobar si:
            //las Pre-Aprobada
            estado_buscado = linker.obtener_dato_especificado("select id_estado from estado where descripcion='Pre-Aprobada' and tema='orden_servicio'" + id, 0);

            if (!estado.Equals(estado_buscado))
            {
                lerror.Text = "Error: solo puede Desaprobar una orden Pre-Aprobada";

            }
            else
            {


                //desapruebo
                //primero las hijas
                id = " id_os=" + Label2.Text;

                estado = linker.obtener_dato(" estados where descripcion='No Aprobada' and tema='detalle_orden' ", 0);

                //especifico campos
                campos.Add("id_estado=");
                campos.Add(estado);

                resultado = linker.actualizacion_personalizada("detalle_orden_de_servicio", id, campos);








                //despues la orden
                id = " id=" + Label2.Text;

                estado = linker.obtener_dato(" estados where descripcion='Desaprobada' and tema='orden_servicio' ", 0);

                //especifico campos
                campos.Add("id_estado=");
                campos.Add(estado);

                resultado = linker.actualizacion_personalizada("orden_de_servicio", id, campos);
            }
        }

    }
}