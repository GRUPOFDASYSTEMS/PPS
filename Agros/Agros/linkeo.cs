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




using System.Data.SqlClient;

namespace Agros
{
    //public class linkeo
    //{
    //}

//    public class linkeo
//    {
//        static MySqlConnection Conex = new MySqlConnection();
//        static string CadenaDeConexion = "Server=localhost;" + "Database=agros;" + "UID=root;" + "Password=;";
//        static MySqlCommand Comando = new MySqlCommand();
//        static MySqlDataAdapter Adaptador = new MySqlDataAdapter();
//        static BindingSource Bind = new BindingSource();

//        public static void Conectar()
//        {


//            try
//            {
//                Conex.ConnectionString = CadenaDeConexion;
//                Conex.Open();
//                //Response.Write("Exito");
//            }
//            catch {
//                //Response.Write("Fallo");
//            }




//        }


//        public static void Desconectar()
//        {
//            Conex.Close();
//        }

//        public DataSet Seleccionar(string campos, string tabla, string orden)
//        {
            
//            //aca podria agregar para que se conecte automaticamente
//            //this.Conectar();

//            string Comando = "select " + campos + " from " + tabla + " order by " + orden + ";";
//            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
//            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
//            DataSet table = new DataSet();
//            Adaptador.Fill(table);
//            return table;
////            Bind.DataSource = table;
//        }





//        public DataSet Seleccion_simple(string consulta)
//        {

//            //aca podria agregar para que se conecte automaticamente
//            //this.Conectar();

//            string Comando = " " + consulta + "  ";
//            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
//            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
//            DataSet table = new DataSet();
//            Adaptador.Fill(table);
//            return table;
//            //            Bind.DataSource = table;
//        }



//        public DataSet Seleccion_estados()
//        {

//            //aca podria agregar para que se conecte automaticamente
//            //this.Conectar();

//            string Comando = " select id_estado, descripcion from estados  ";
//            Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
//            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
//            DataSet table = new DataSet();
//            Adaptador.Fill(table);
//            return table;
//            //            Bind.DataSource = table;
//        }










//        public static BindingSource Bin
//        {
//            get
//            {
//                return Bind;
//            }
//        }
//    }


    public class linkeo //link_mssql
    {

      String sqlServerLogin = "user_id";
      String password = "pwd";
      String instanceName = "instance_name";
      String remoteSvrName = "remote_server_name";
      SqlConnection conexion = new SqlConnection("Data Source=.\\localhost;Database=Agros;Integrated Security=SSPI");


      //public static void conectar_ms()
      //{
      //      // Connecting to an instance of SQL Server using SQL Server Authentication
      //    Server srv1 = new Server();   // connects to default instance
      //    //srv1.ConnectionContext.LoginSecure = false;   // set to true for Windows Authentication
      //    //srv1.ConnectionContext.Login = sqlServerLogin;
      //    //srv1.ConnectionContext.Password = password;
            
      //    Console.WriteLine(srv1.Information.Version);   // connection is established
            
      //}











        public DataSet Seleccion_estados_ms()
        {

            //aca podria agregar para que se conecte automaticamente
            //this.Conectar();

            
            SqlCommand Comando = new SqlCommand (" select * from estados  ", conexion);
            conexion.Open();
            SqlDataReader select = Comando.ExecuteReader();
            SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
            SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);
            

            //Adaptador = new MySqlDataAdapter(Comando, CadenaDeConexion);
            //MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(Adaptador);
            DataSet table = new DataSet();
            Adaptador.Fill(table);

            conexion.Close();
            return table;
            
        }





        public DataSet Seleccion_estados_ms_puro()
        {

            //aca podria agregar para que se conecte automaticamente
            //this.Conectar();


            //SqlCommand Comando = new SqlCommand(" select * from estados  ");
            string Comando = " select id_estado, descripcion from estados  ";

            SqlDataAdapter Adaptador = new SqlDataAdapter(Comando, conexion);
            SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);


            DataSet table = new DataSet();
            Adaptador.Fill(table);

            
            return table;

        }





        public DataSet Seleccion_simple(string c)
        {

            //aca podria agregar para que se conecte automaticamente
            //this.Conectar();


            //SqlCommand Comando = new SqlCommand(" select * from estados  ");
            string Comando = c;

            SqlDataAdapter Adaptador = new SqlDataAdapter(Comando, conexion);
            SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);


            DataSet table = new DataSet();
            Adaptador.Fill(table);


            return table;

        }



    }

}
