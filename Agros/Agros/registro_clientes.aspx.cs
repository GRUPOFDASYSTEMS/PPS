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
    public partial class registro_clientes : System.Web.UI.Page
    {
        /*global*/
        linkeo linker = new linkeo();
        string nuevakey;

        protected void Page_Load(object sender, EventArgs e)
        {
            /* SETEOS GENERALES*/
            Label1.ForeColor = System.Drawing.Color.Red;

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







            if (Session["cliente"].ToString().Equals("0"))
                backtoindexcliente.Visible = false;
            else
                completarlosDatos(Session["cliente"].ToString());


        }


        protected void completarlosDatos(string cc)
        {
            DataSet c = new DataSet();
            c = linker.Seleccion_por_id_y_consulta("select id, cuit, razon_social, direccion, password, condicion_iva, email from cliente where id=",cc);

            for (int i=0; i < c.Tables[0].Rows.Count; i++)
            {
                cuit.Text=c.Tables[0].Rows[i][1].ToString();
                rs.Text = c.Tables[0].Rows[i][2].ToString();
                dir.Text = c.Tables[0].Rows[i][3].ToString();
                clave.Text = c.Tables[0].Rows[i][4].ToString();
                DropDownList1.SelectedValue = c.Tables[0].Rows[i][5].ToString();
                email.Text = c.Tables[0].Rows[i][6].ToString();
                // es operario favorito quiza si lo ponemos aca debemos ver el tema de la actualizacion de la confianza in situ 
                // y eliminar la pagina de configuracion, por ultimo agregar la habilitacion de este dropdownlist al final  = c.Tables[0].Rows[i][6].ToString();

            }


            //habilito/deshabilito  los controles para esta instancia
            this.Button1.Visible = false;
            this.update.Visible = true;


        
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            ArrayList campos = new ArrayList();
            ArrayList datos = new ArrayList();
            string resultado;

            //especifico campos
            campos.Add("cuit, ");
            campos.Add("password, ");
            campos.Add("razon_social, ");
            campos.Add("direccion, ");
            campos.Add("condicion_iva, ");
            campos.Add("email, ");
            campos.Add("id_estado, ");
            campos.Add("operario_favorito");

            //recolecto datos             
            datos.Add(this.cuit.Text);//cuit int
            datos.Add(" , ");
            datos.Add(this.clave.Text);//cla  int
            datos.Add(" , ");
            datos.Add("'");
            datos.Add(this.rs.Text);//raz varchar
            datos.Add("'");
            datos.Add(" , ");
            datos.Add("'");
            datos.Add(this.dir.Text);//dir varchar
            datos.Add("'");
            datos.Add(" , ");
            datos.Add(this.DropDownList1.SelectedValue);//cf int
            datos.Add(" , ");
            datos.Add("'");
            datos.Add(this.email.Text);//email varchar
            datos.Add("'");
            datos.Add(" , ");
            datos.Add("1");
            datos.Add(" , ");
            datos.Add("1");


            resultado =linker.insercion_de_dataset("cliente", campos, datos);
            //Label1.Text = resultado;
            string[] devolucion = new string[3];
            devolucion = linker.revisar_error(resultado, "INS", "Bienvenido A Agros, Ya Puede Ingresar Con Su Numero De Cuit Registrado Y Su Clave", "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion", "login_clientes.aspx", "registro_clientes.aspx");
            

            if (devolucion[0].Equals("0"))
            Session["mensaje_error"] = devolucion[1];
            else
            Session["mensaje_exito"] = devolucion[1];

            Response.Redirect(devolucion[2]);


        }



        

        protected void update_Click(object sender, EventArgs e)
        {
            string id = Session["cliente"].ToString();
            ArrayList campos = new ArrayList();
            
            string resultado;

            //especifico campos
            campos.Add("cuit= ");
            campos.Add(cuit.Text);//cuit int
            campos.Add(", ");
            campos.Add("password=");
            campos.Add(clave.Text);//cla  int
            campos.Add(", ");
            campos.Add("razon_social=");
            campos.Add("'");
            campos.Add(rs.Text);//raz varchar
            campos.Add("'");
            campos.Add(", ");
            campos.Add("direccion=");
            campos.Add("'");
            campos.Add(dir.Text);//dir varchar
            campos.Add("'");
            campos.Add(", ");
            campos.Add("condicion_iva=");
            campos.Add(DropDownList1.SelectedValue);//cf int
            campos.Add(", ");
            campos.Add("email=");
            campos.Add("'");
            campos.Add(email.Text);//email varchar
            campos.Add("'");
            
            
            //campos.Add(", ");
            //????I dont Know... campos.Add("operario_favorito");



            resultado = linker.actualizacion_de_dataset("cliente", id, campos);
            //Label1.Text = resultado;
            string[] devolucion = new string[3];
            devolucion = linker.revisar_error(resultado, "UPD", "Datos Actualizados Correctamente", "Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion", "registro_clientes.aspx", "registro_clientes.aspx");


            if (devolucion[0].Equals("0"))
                Session["mensaje_error"] = devolucion[1];
            else
                Session["mensaje_exito"] = devolucion[1];

            Response.Redirect(devolucion[2]);
             

        }

        protected void clave_TextChanged(object sender, EventArgs e)
        {
            nuevakey = this.clave.Text;
        }



    }
}
