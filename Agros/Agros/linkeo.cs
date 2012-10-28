using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;




namespace Agros
{
    //public class linkeo
    //{
    //}

    public class linkeo
    {
        static MySqlConnection Conex = new MySqlConnection();
        static string CadenaDeConexion = "Server=localhost;" + "Database=agros;" + "UID=root;" + "Password=;";
        static MySqlCommand Comando = new MySqlCommand();
        static MySqlDataAdapter Adaptador = new MySqlDataAdapter();
        static BindingSource Bind = new BindingSource();

        public static void Conectar()
        {


            try
            {
                Conex.ConnectionString = CadenaDeConexion;
                Conex.Open();
                //Response.Write("Exito");
            }
            catch {
                //Response.Write("Fallo");
            }




        }


        public static void Desconectar()
        {
            Conex.Close();
        }

        public DataSet Seleccionar(string campos, string tabla, string orden)
        {
            
            //aca podria agregar para que se conecte automaticamente
            //this.Conectar();

            string Comando = "select " + campos + " from " + tabla + " order by " + orden + ";";
            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
            DataSet table = new DataSet();
            Adaptador.Fill(table);
            return table;
//            Bind.DataSource = table;
        }





        public DataSet Seleccion_simple(string consulta)
        {

            //aca podria agregar para que se conecte automaticamente
            //this.Conectar();

            string Comando = " " + consulta + "  ";
            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
            DataSet table = new DataSet();
            Adaptador.Fill(table);
            return table;
            //            Bind.DataSource = table;
        }



        public DataSet Seleccion_estados()
        {

            //aca podria agregar para que se conecte automaticamente
            //this.Conectar();

            string Comando = " select id_estado, descripcion from estados  ";
            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
            DataSet table = new DataSet();
            Adaptador.Fill(table);
            return table;
            //            Bind.DataSource = table;
        }










        public static BindingSource Bin
        {
            get
            {
                return Bind;
            }
        }
    }




}
