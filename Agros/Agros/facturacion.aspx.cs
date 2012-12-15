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
    public partial class facturacion : System.Web.UI.Page
    {

        linkeo linker = new linkeo();
        nueva_pagina np = new nueva_pagina();
        string estadoCorrecto, resultado, error = "";
        ArrayList datos = new ArrayList();



        protected void Page_Load(object sender, EventArgs e)
        {
            LabelInfo.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void dgvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[1].Text;
            LabelIdF.Text = id;
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void VerD_Click(object sender, ImageClickEventArgs e)
        {
            if (aseguroId())
            {
                Session["id_factura"] = LabelIdF.Text;
                Session["backtousuario"] = "1";
                Response.Redirect("facturacion_detalle_facturas.aspx");
            }
        }


        protected bool aseguroId() {

            if (LabelIdF.Text.Length > 0)
                return true;
            else
            {
                LabelInfo.Text = "Debe Seleccionar Una Factura Antes De Continuar";
                return false;
            }
        }

        protected void pinto(string s) {


            s = s.Length > 0 ? s : "Error";

        if (s.Substring(0,5)=="Error")
            LabelInfo.ForeColor = System.Drawing.Color.Red;
        else
            LabelInfo.ForeColor = System.Drawing.Color.Green;
        
        }


        protected void actualizoFactura(string estado_nuevo, string estado_permitido)
        {

            if (aseguroId())
            {
                //"Informada"
                estadoCorrecto = np.obtenerEstados("facturas", LabelIdF.Text, estado_permitido, "facturacion");

                if (estadoCorrecto == "OK")
                {

                    //limpio datos
                    datos.RemoveRange(0, datos.Count);

                    //busco datos  //Pagada
                    estadoCorrecto = linker.obtener_dato_especificado("select id from estados where descripcion='"+estado_nuevo+"' and tema= 'facturacion'", 0);


                    //agrego
                    datos.Add("id_estado=");
                    datos.Add(estadoCorrecto);

                    resultado = linker.actualizacion_de_dataset("facturas", LabelIdF.Text, datos);

                    error = np.verificarOperacion(resultado, "UPD") ? "Se ha procesado la factura de manera exitosa" : "Error: Ha ocurrido un error al intentar actualizar la factura";

                }
                else
                    error = estadoCorrecto;

            }

            LabelInfo.Text = error == "" ? LabelInfo.Text: error;
            pinto(error);
        }




        protected void InfComoPag_Click(object sender, ImageClickEventArgs e)
        {

            actualizoFactura("Pagada", "Informada");
            
        }

        protected void DesinfPago_Click(object sender, ImageClickEventArgs e)
        {
            actualizoFactura("Pendiente", "Informada");
        }

        protected void Incons_Click(object sender, ImageClickEventArgs e)
        {
            actualizoFactura("Inconsistente", "Informada");
        }
    }
}
