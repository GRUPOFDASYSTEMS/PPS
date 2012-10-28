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
using System.Data.SqlClient;

namespace Agros
{
    public partial class configurar_cliente : System.Web.UI.Page
    {
        private DataTable dt;
        private SqlDataAdapter da;
        private int fila;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //private void mostrarDatos(int f)
        //{
        //    int uf = dt.Rows.Count - 1;
        //    if (f < 0 || uf < 0) return;
        //    //
        //    DataRow dr = dt.Rows[f];
        //    Label1.Text = dr["ID"].ToString();
        //    Label2.Text = dr["Descripcion"].ToString();

        //    //btnActualizar.Enabled = true;
        //    //btnEliminar.Enabled = true;
        //}



        //public void consulta_simple() {
        //    Conexion_BD conn = new Conexion_BD();
        //    conn.m_adapter='S';
        //    conn.m_credentials='root';
            


        //    conn.Conectar();

        //    //Declaración de variables requeridas
        //    SqlCommand SQLcmd = new SqlCommand();
        //    DataTable table = new DataTable();

        //    // obtener la cadena de conexion con el servidor BD
        //  //  m_connection.ConnectionString = "server=" + textBox1.Text + ";uid=" + textBox2.Text + ";pwd=" + textBox3.Text + ";";

        //    //Asignación de propiedades
        //    SQLcmd.Connection = m_connection;
        //    SQLcmd.CommandType = CommandType.Text;
        //    // formar la consulta a pedir
        //    SQLcmd.CommandText = "select * from [Agros].[dbo].Estados";

        //    // Ejecutar la consulta
        //    m_adapter.SelectCommand = SQLcmd;

        //    mostrarDatos(0);

        //   // mbox.show(SQLcmd.ToString);

        //   // mbox.show(SQLcmd.ToString);


        //}

    }
}
