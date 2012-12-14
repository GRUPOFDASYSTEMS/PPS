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
    public partial class abmrestriccion_licencias_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected bool validar(){
            //valido fechas correctas
            int compf = Calendar1.SelectedDate.CompareTo(Calendar2.SelectedDate);
            bool v = false;

            if (compf < 1)
                v = true;
            else
            {

                LabelInfo.ForeColor = System.Drawing.Color.Red;
                LabelInfo.Text = "Recuerde que la fecha de fin debe ser posterior a la fecha de inicio";
            }


            if (f_in.Text == "" || f_out.Text == "")
            {
                v = false;
                LabelInfo.ForeColor = System.Drawing.Color.Red;
                LabelInfo.Text = "Debe seleccionar decha de inicio y fecha de fin";


            }

        return v;
        
        }




        protected void Button2_Click(object sender, EventArgs e)
        {
            linkeo linker = new linkeo();
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado;
            



            if (validar())
            {
                //obtengo fechas formateadas
                string fecha = Calendar1.SelectedDate.ToString("yyyyMMdd");
                string fecha2 = Calendar2.SelectedDate.ToString("yyyyMMdd");
                DateTime fecha_actual = DateTime.Now;
                string fa = fecha_actual.ToString("yyyyMMdd");

                //especifico campos
                campos.Add("fecha_registracion, ");//despues probar si ingresa ok, sino... sacar
                campos.Add("fecha_inicio, ");
                campos.Add("fecha_fin, ");
                campos.Add("descripcion, ");
                campos.Add("id_usuario ");
                //recolecto datos
                datos.Add(" ' ");
                datos.Add(fa);
                datos.Add(" ' ");
                datos.Add(" , ");
                datos.Add(" ' ");
                datos.Add(fecha);//tiempo inicial
                datos.Add(" ' ");
                datos.Add(" , ");
                datos.Add(" ' ");
                datos.Add(fecha2);//tiempo final
                datos.Add(" ' ");
                datos.Add(" , ");
                datos.Add(" ' ");
                datos.Add(this.TextBox4.Text);//des
                datos.Add(" ' ");
                datos.Add(" , ");
                datos.Add(this.DropDownList1.SelectedValue);//idu


                resultado = linker.insercion_de_dataset("restriccion_disponibilidad_usuario", campos, datos);



                //verifico respuesta
                string[] devolucion = new string[3];
                devolucion = linker.revisar_error(resultado, "INS", "", "", "", "");




                if (devolucion[0].Equals("0"))
                {
                    //Session["mensaje_error"] = devolucion[1];
                    LabelInfo.ForeColor = System.Drawing.Color.Red;
                    LabelInfo.Text = "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion";
                }
                else
                {
                    //Session["mensaje_exito"] = devolucion[1];
                    LabelInfo.ForeColor = System.Drawing.Color.Green;
                    LabelInfo.Text = "Datos Cargados Correctamente. Puede continuar agregando datos o si desea finalizar pulse el boton FINALIZAR EDICION ";
                }

                //No uso por ahora
                //Response.Redirect(devolucion[2]); 
                Button2.Enabled = false;
            }

        }



        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string fecha = String.Format("{0:yyyyMMdd}", this.Calendar1.SelectedDate.ToShortDateString());
            f_in.Text = "Fecha Seleccionada: " + fecha;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            string fecha2 = String.Format("{0:yyyyMMdd}", this.Calendar2.SelectedDate.ToShortDateString());
            f_out.Text = "Fecha Seleccionada: " + fecha2;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmrestriccion_licencias_in.aspx");
        }
    }
}
