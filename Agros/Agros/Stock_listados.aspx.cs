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
    public partial class Stock_listados : System.Web.UI.Page
    {
        linkeo linker = new linkeo();
        nueva_pagina np = new nueva_pagina();
        string id, rm, resultado;


        protected void Page_Load(object sender, EventArgs e)
        {


        }

        

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "";        
        }

        protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = this.dgvDatos.Rows[this.dgvDatos.SelectedIndex].Cells[1].Text;
            Label1.Text = id;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Label1.Text;



            if ((rm = np.mensaje_marca(id)).Length < 1)
            {

                string id_valor = " id_producto=" + id;

                string valor = TextBox1.Text;
                ArrayList campos_y_valores = new ArrayList();

                //agrego datos
                campos_y_valores.Add("cantidad=cantidad+"); //
                campos_y_valores.Add(valor);

                resultado = linker.actualizacion_personalizada("stock", id_valor, campos_y_valores);                
                

                string[] devolucion = new string[3];
                devolucion = linker.revisar_error(resultado, "UPD", "Datos Actualizados Correctamente", "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion", "stock_listados.aspx", "stock_listados.aspx");


                if (devolucion[0].Equals("0"))
                    Session["mensaje_error"] = devolucion[1];
                else
                    Session["mensaje_exito"] = devolucion[1];



                Response.Redirect(devolucion[2]);

            }
            else
                Response.Write(rm);


        }


        protected void Button2_Click1(object sender, EventArgs e)
        {
            string id = Label1.Text;


            if ((rm = np.mensaje_marca(id)).Length < 1)
            {


                string id_valor = " id_producto=" + id;
                string valor = TextBox2.Text;
                ArrayList campos_y_valores = new ArrayList();

                //agrego datos
                campos_y_valores.Add("cantidad="); //
                campos_y_valores.Add(valor);


                resultado = linker.actualizacion_personalizada("stock", id_valor, campos_y_valores);


               

                string[] devolucion = new string[3];
                devolucion = linker.revisar_error(resultado, "UPD", "Datos Actualizados Correctamente", "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion", "stock_listados.aspx", "stock_listados.aspx");


                if (devolucion[0].Equals("0"))
                    Session["mensaje_error"] = devolucion[1];
                else
                    Session["mensaje_exito"] = devolucion[1];



                Response.Redirect(devolucion[2]);

            }
            else
                Response.Write(rm);



        }




    }
}
