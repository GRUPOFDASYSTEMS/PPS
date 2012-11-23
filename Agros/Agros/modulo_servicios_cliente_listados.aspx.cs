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

        }

        protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Apruebo todas las ordenes hijas y tambien el estado de la orden general
            //primero las hijas
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado, id, estado, detalle, precio, cantidad, select;
            int id_f;
            
            id = " id_os="+Label2.Text;

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
            string fechas=fecha.ToString("yyyyMMdd");
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
            select = "(select ds.descripcion from detalle_servicio ds, detalle_orden_de_servicio dos where dos.id_detalle_servicio=ds.id and dos.id_os="+id+")x"; 
            //id_factura
            id_f = linker.obtener_id("facturas");

            //detalle (segun detalle_servicio asociado a detalle_orden_de_servicio)
            //esto funciona para un solo caso... pero hay que hacer un bucle para todos
            //DEVOLVER UN ARRAY O UN DATASET... Y EOF()
            detalle = linker.obtener_dato(select, 0);

            //monto_unitario
            //QUIZA EL ES MISMO DATA SET DADO QUE... OJO EL ID QUE USAMOS!!
            select = "(select ds.precio from detalle_servicio ds, detalle_orden_de_servicio dos where dos.id_detalle_servicio=ds.id and dos.id_os=" + Label2.Text + ")x";
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

            //iva, por ahora siempre 21%, ojo, aca va en valores
            
            
            //modelo de ejemplo... cambiar segun corresponda...

            //campos.Add("fecha, ");
            //campos.Add("id_os, ");
            //campos.Add("id_estado, ");
            //campos.Add("id_cliente");

            ////fecha es hoy
            //DateTime fecha = DateTime.Now;
            //fecha.ToString("yyyyMMdd");
            ////id_os es id
            //id = Label2.Text;

            ////el estado es siempre pendiente al inicio
            //estado = linker.obtener_dato(" estados where descripcion='Pendiente' and tema='facturacion' ", 0);

            ////y el cliente asociado
            ////Session["cliente"].ToString(); &&lo escribo directamente...
            //datos.Add(" ' ");
            //datos.Add(fecha);
            //datos.Add(" ' ");
            //datos.Add(" , ");
            //datos.Add(id);
            //datos.Add(" , ");
            //datos.Add(estado);
            //datos.Add(" , ");
            //datos.Add(Session["cliente"].ToString());


 





 




        }

        protected void dgvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[1].Text;
            Label2.Text = id;
        }




    }
}
