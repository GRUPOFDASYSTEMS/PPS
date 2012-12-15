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
    public partial class servicios_operarios_general : System.Web.UI.Page
    {

        linkeo linker = new linkeo();
        nueva_pagina np = new nueva_pagina();
        modulo_servicios_listado_detalle_orden det = new modulo_servicios_listado_detalle_orden();

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelInfo.Text = "";
        }



        protected void dgvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[1].Text;
            LabelSe.Text = id;

        }

        protected void PreAprobar_Click(object sender, EventArgs e)
        {
            //primero debemos obtener el id_os
            if (LabelSe.Text.Length > 0)
            {
                string id_os = linker.obtener_dato_especificado("select id_os from detalle_orden_de_servicio where id=" + LabelSe.Text, 0);

                if (id_os == "-1")
                    LabelInfo.Text = "No se encontro la orden de servicio asociada.";
                else
                {
                    LabelInfo.Text = det.ejecutarActualizacionDetalleOrden("Pre-Aprobada", "", false, LabelSe.Text, "", "No Aprobada", id_os, false)[1];

                    if (LabelInfo.Text == "OK")
                        Response.Redirect("servicios_operarios_general.aspx");
                }
            }
            else
                LabelInfo.Text = "Asegurese de haber seleccionado un item antes de continuar.";
        }

        protected void com_Click(object sender, EventArgs e)
        {





            if (LabelSe.Text.Length > 0)
            {
                LabelInfo.Text = det.ejecutarActualizacionDetalleOrden("solo comentar", comentario.Text, false, "", LabelSe.Text, "noimportaelestado", "", false)[1];
                Response.Redirect("servicios_operarios_general.aspx");
            }
            else
                LabelInfo.Text = "Asegurese de haber seleccionado un item antes de continuar.";

        }

        protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }





    }
}
