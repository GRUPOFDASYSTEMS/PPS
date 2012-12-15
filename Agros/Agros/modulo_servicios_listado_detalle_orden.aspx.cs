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
    public partial class modulo_servicios_listado_detalle_orden : System.Web.UI.Page
    {

        linkeo linker = new linkeo();
        nueva_pagina np = new nueva_pagina();
        string id, ids, idse, estado, resultado, rm;
        
 

        protected void Page_Load(object sender, EventArgs e)
        {
            interpretar_instancia();
        }


        public void interpretar_instancia() { 
        
        string id = Session["id_os"].ToString();
        string creando = linker.obtener_dato_especificado("select id from estados where descripcion='En Proceso de creacion' and tema='orden_servicio' ", 0);
        string estado = linker.obtener_dato_especificado("select id_estado from orden_de_servicio where id=" + id, 0);


        if (creando.Equals(estado))
            Response.Redirect("modulo_servicios_creando_detalle_orden.aspx");
        
            //caso contrario debo editar cada uno de los items (aprobarlos/desaprobarlos/oquiza abortarlos)


        }

        protected void dgvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "Usted ha marcado el Pack Servicio: ";
            string id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[1].Text;
            LabelIds.Text = id;

        }

        protected void dgvDatosServicioEspecifico_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label2.Text = "Usted ha marcado el Servicio Especifico: ";
            string id = this.dgvDatosServicioEspecifico.Rows[this.dgvDatosServicioEspecifico.SelectedIndex].Cells[1].Text;
            LabelSe.Text = id;
        }

        protected void Aprobar_Click(object sender, EventArgs e)
        {
            string consulta;
            //Aprobada
            string[] observar = new string[2]; 
            observar =ejecutarActualizacionDetalleOrden("Aprobada", "", false, LabelIds.Text, LabelSe.Text, "Pre-Aprobada", Session["id_os"].ToString(), false);
            LabelInfo.Text = observar[1];

            if (observar[0] == "1")
            {
                //verifico si todas estan aprobadas...
                consulta = " estados where descripcion='No Aprobada' and tema='detalle_orden' ";
                estado = linker.obtener_dato(consulta, 0);
                string desaprobadas = linker.obtener_dato_especificado(" select id from detalle_orden_de_servicio where id_estado=" + estado + " and id_os=" + Session["id_os"].ToString(), 0);
                consulta = " estados where descripcion='Pre-Aprobada' and tema='detalle_orden' ";
                estado = linker.obtener_dato(consulta, 0);
                string preaprobadas = linker.obtener_dato_especificado(" select id from detalle_orden_de_servicio where id_estado=" + estado + " and id_os=" + Session["id_os"].ToString(), 0);


                //si no existen mas ordenes para aprobar, genero factura...
                if ((desaprobadas == "-1") && (preaprobadas == "-1"))
                 {
                    
                    //primero debo pasar la orden padre al estado pre-aprobado---
                     consulta = " estados where descripcion='Pre-Aprobada' and tema='orden_servicio' ";
                     estado = linker.obtener_dato(consulta, 0);

                     ArrayList datos = new ArrayList();
                     datos.Add("id_estado=");
                     datos.Add(estado);

                     linker.actualizacion_de_dataset("orden_de_servicio", Session["id_os"].ToString(), datos);

                    //luego facturar
                     LabelInfo.Text = np.generarFactura(Session["id_os"].ToString(), Session["cliente"].ToString());

                    if (LabelInfo.Text.Substring(0, 5) == "Error")
                        LabelInfo.ForeColor = System.Drawing.Color.Red;
                    else
                        LabelInfo.ForeColor = System.Drawing.Color.Green;
                }

            }

        }


        
        
        
        
        
        
        
        protected void Desaprobar_Click(object sender, EventArgs e)
        {
            LabelInfo.Text = ejecutarActualizacionDetalleOrden("No Aprobada", "", true, LabelIds.Text, LabelSe.Text, "Pre-Aprobada", Session["id_os"].ToString(), true)[1];
        }

        protected void com_Click(object sender, EventArgs e)
        {
            LabelInfo.Text = ejecutarActualizacionDetalleOrden("solo comentar", comentario.Text, true, LabelIds.Text, LabelSe.Text, "noimportaelestado", Session["id_os"].ToString(), true)[1];
        }


        //quiza podria abortarla tmb... vems el tiempo





        public string[] ejecutarActualizacionDetalleOrden(string ejecucion, string comentar, bool actualizar, string ids, string idse, string estado_permitido, string id_os, bool llamadainterna)
        {

            string consulta = "", error_estados = "", permitido ="0";
            string[] res = new string[2];
           // ids = LabelIds.Text;
            //idse = "";
            //bool permitido = false;

            if (comentar.Length < 1)
            {
                //deberia ver si os estados se permiten...
                //error_estados = np.obtenerEstados("orden_de_servicio", Session["id_os"].ToString(), ejecucion, "orden_servicio");

                error_estados = np.obtenerEstados("detalle_orden_de_servicio", ids.Length >0 ? ids:idse , estado_permitido, "detalle_orden");
                permitido = error_estados == "OK"?"1":"0";
            }
            else
                permitido = "1";
            

            consulta = " estados where descripcion='"+ejecucion+"' and tema='detalle_orden' ";
            estado = linker.obtener_dato(consulta, 0);


            


            /* Si no marco un pack, voy por el detalle...*/
            if (permitido == "1")
            {
                if (ids.Length < 1)
                {
                    ArrayList campos = new ArrayList();
              //      idse = LabelSe.Text;

                    if ((rm = np.mensaje_marca(idse)).Length < 1)
                    {


                        id = " id=" + idse;



                        //especifico campos
                        if (comentar.Length < 1)
                        {
                            campos.Add("id_estado=");
                            campos.Add(estado);
                        }

                        else
                        {
                            campos.Add("comentario=");
                            campos.Add("'");
                            campos.Add(comentar);
                            campos.Add("'");
                        }


                            resultado = linker.actualizacion_personalizada("detalle_orden_de_servicio", id, campos);

                            if ((verificarActualizacion(resultado, "Atencion! la orden de servicio marcada no se pudo actualizar", llamadainterna)) && llamadainterna)
                                Response.Redirect("modulo_servicios_listado_detalle_orden.aspx");

   




                    }
                    else
                        Response.Write(rm);

                }
                /* Si marco un pack, voy por el pack y los detalles...*/
                else
                {
                    ArrayList campos = new ArrayList();
                    bool exito;
                    //Apruebo todas las ordenes hijas y tambien el estado de la orden general


                    if (comentar.Length < 1)
                    {
                        //primero las hijas
                        id = " asoc_interna_id_servicio=" + ids + " and id_os=" + id_os;

                        //especifico campos
                        campos.Add("id_estado=");
                        campos.Add(estado);

                        resultado = linker.actualizacion_personalizada("detalle_orden_de_servicio", id, campos);

                        exito = verificarActualizacion(resultado, "Atencion! las ordenes de servicio asociadas al pack de servicio no se pudieron actualizar", llamadainterna);

                        //despues la orden
                        campos.RemoveRange(0, campos.Count);
                        id = " id=" + ids;


                        //especifico campos
                        campos.Add("id_estado=");
                        campos.Add(estado);

                        resultado = linker.actualizacion_personalizada("detalle_orden_de_servicio", id, campos);

                        if ((verificarActualizacion(resultado, "Atencion! el pack de servicio no se pudo actualizar", llamadainterna)) && (exito) && (actualizar) && (llamadainterna) )
                            Response.Redirect("modulo_servicios_listado_detalle_orden.aspx");

                    }
                    else
                    {

                        campos.Add("comentario=");
                        campos.Add("'");
                        campos.Add(comentar);
                        campos.Add("'");
                        resultado = linker.actualizacion_personalizada("detalle_orden_de_servicio", id, campos);

                        if ((verificarActualizacion(resultado, "Atencion! el pack de servicio no se pudo actualizar", llamadainterna)) && (actualizar) && (llamadainterna))
                            Response.Redirect("modulo_servicios_listado_detalle_orden.aspx");

                    }





                }
            }
            else
            {
                error_estados = error_estados.Substring(0, 5) == "Error" ? "Solo es posible cambiar el estado a " + ejecucion + " cuando la orden de servicio se encuentra en estado '"+estado_permitido+"' " : error_estados;
            }

            res[0] = permitido;
            res[1] = error_estados;

            return res;
        
        }






        public bool verificarActualizacion(string resultado, string mensaje, bool llamadainterna)
        {

            //verifico respuesta
            bool res = true;
            string[] devolucion = new string[3];
            devolucion = linker.revisar_error(resultado, "UPD", "", "", "", "");




            if (devolucion[0].Equals("0"))
            {
                if (llamadainterna)
                {
                    LabelInfo.ForeColor = System.Drawing.Color.Red;
                    LabelInfo.Text = mensaje;
                }
                res = false;
            }

            return res;

        }



    }
}
