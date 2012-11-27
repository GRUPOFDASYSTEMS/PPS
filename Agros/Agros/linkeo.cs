using System;
using System.Collections;
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


    public class linkeo //link_mssql
    {
/********DATOS DE CONEXION EN NOTEBOOK*******/
     // static SqlConnection conexion = new SqlConnection("Data Source=ALEX\\FDA;MultipleActiveResultSets=True;Initial Catalog=master;Integrated Security=True");



/********DATOS DE CONEXION EN PC*******/
    //Data Source=.\SQLEXPRESS;AttachDbFilename="D:\FDA\BASES DE DATOS 2011\master.mdf";Integrated Security=True;Connect Timeout=30;User Instance=True
     // la que tiene datos pero no podemos acceder... static SqlConnection conexion = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename='D:\master.mdf';Integrated Security=True;Connect Timeout=30;User Instance=True");


//la que si nos deja... (Pero faltan algunas tablas .. llenar a medida que se necesite)
        static SqlConnection conexion = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\FDA\BASES DE DATOS 2011\master.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
//ultima prueba  evito la master y no dejo el ldf en el mismo dir luegop queda ver si el directorio esta permintido
   /* dont work... */    // static SqlConnection conexion = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\FDA\BASES DE DATOS 2011\agrocomp.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        public static void SetInitValues(string[] myList, int limite)
        {
            string res = "";

            for (int i=0; i<limite;i++)
                myList[i]=res;

            
        }

        public static string PrintValues(IEnumerable myList)
        {
            string res = "";
            foreach (Object obj in myList)
                res = res + obj;

            return res;
        }




      //select c.id_cliente as id, c.razon_social as 'Razon Social', c.direccion as 'Direccion', c.cuit as 'Cuit', c.confianza as 'Confianza', u.nombre as 'Operario Favorito', i.descripcion as 'Condicion Fiscal', email as 'E-Mail' from cliente c, usuario u, condicion_iva i  where c.operario_favorito=u.id_usuario and c.condicion_iva=i.id_condicion
        public DataSet Seleccion_en_dataset (string consulta)
        {

            //aca podria agregar para que se conecte automaticamente
            DataSet table = new DataSet();
            SqlCommand Comando = new SqlCommand (consulta, conexion);
            try
            {
                conexion.Open();
                SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
                SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);
                Adaptador.Fill(table);
            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                table = null;                

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }


            return table;
            
        }





        public DataSet Seleccion_por_id_y_consulta(string consulta, string id)
        {

            DataSet table = new DataSet();
            consulta = consulta + id;
            SqlCommand Comando = new SqlCommand(consulta, conexion);

            try
            {
                conexion.Open();

                SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
                SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);

                Adaptador.Fill(table);
            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                table = null;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            return table;

        }




        public DataSet Seleccion_por_doble_id(string consulta, string id, string id2)
        {

            DataSet table = new DataSet();
            consulta = consulta + id + id2;
            SqlCommand Comando = new SqlCommand(consulta, conexion);

            try
            {
                conexion.Open();

                SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
                SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);

                Adaptador.Fill(table);
            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                table = null;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            return table;

        }



        public DataSet Seleccion_por_multiple_condicion(string consulta, string cond1, string cond2, string cond3)
        {

            DataSet table = new DataSet();
            consulta = consulta + cond1 + cond2 + cond3; 
            SqlCommand Comando = new SqlCommand(consulta, conexion);

            try
            {
                conexion.Open();

                SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
                SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);

                Adaptador.Fill(table);
            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                table = null;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            return table;

        }






        public DataSet Seleccion_segun_id_para_consultar(string consulta1, string consulta2, string consulta3, string id)
        {

            DataSet table = new DataSet();
            string consulta= "";
            
            switch (id)
            {
                case "3":
                    consulta = consulta1;
                    break;

                case "4":
                    consulta = consulta2;
                    break;

                case "5":
                    consulta = consulta3;
                    break;

            }
            
            
           
            SqlCommand Comando = new SqlCommand(consulta, conexion);

            try
            {
                conexion.Open();

                SqlDataAdapter Adaptador = new SqlDataAdapter(Comando);
                SqlCommandBuilder cm = new SqlCommandBuilder(Adaptador);
                
                Adaptador.Fill(table);
            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                table = null;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            return table;

        }





        public int obtener_id(string tabla)
        {

            int id = 0;
            string maxid = "-1";
            string consulta = "";

            
            consulta = "select max(id)  from " + tabla ;


            SqlCommand Comando = new SqlCommand(consulta, conexion);
            
            

            try
            {
                conexion.Open();
                Comando.CommandText = consulta;
                Comando.CommandType = CommandType.Text;
                SqlDataReader reader = Comando.ExecuteReader();

                if (reader.Read())
                {
                    maxid = reader[0].ToString();
                }
                reader.Close();


                id = Int32.Parse(maxid);
                
            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                id = -1;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }


            
            return id;

        }


        public int ver_si_existe(string tabla_y_condicion)
        {

            int id = 0;
            string maxid = "-1";
            string consulta = "";


            consulta = "select *  from " + tabla_y_condicion;


            SqlCommand Comando = new SqlCommand(consulta, conexion);



            try
            {
                conexion.Open();
                Comando.CommandText = consulta;
                Comando.CommandType = CommandType.Text;
                SqlDataReader reader = Comando.ExecuteReader();

                if (reader.Read())
                {
                    maxid = reader[0].ToString();
                }
                reader.Close();


                id = Int32.Parse(maxid);

            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                id = -1;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }



            return id;

        }



        public string obtener_dato(string tabla_y_condicion, int columna)
        {

            
            string valor_buscado = "-1";
            string consulta = "";


            consulta = "select *  from " + tabla_y_condicion;


            SqlCommand Comando = new SqlCommand(consulta, conexion);



            try
            {
                conexion.Open();
                Comando.CommandText = consulta;
                Comando.CommandType = CommandType.Text;
                SqlDataReader reader = Comando.ExecuteReader();

                if (reader.Read())
                {
                    valor_buscado = reader[columna].ToString();
                }
                reader.Close();


            

            }

            catch (SqlException ex)
            {

                // mostrar error
                // mostrar error
                string error = "1 " + consulta;  //genero el valor 1 al inicio de la cadena, para reconocer el error afuera
                error = error + ex.ToString();
                valor_buscado = tratar_error(error);


            }

            finally
            {
                // Close Connection
                conexion.Close();
            }



            return valor_buscado;

        }



        public string obtener_dato_especificado(string consulta_y_condicion, int columna)
        {


            string valor_buscado = "-1";
            string consulta = "";


            consulta = consulta_y_condicion;


            SqlCommand Comando = new SqlCommand(consulta, conexion);



            try
            {
                conexion.Open();
                Comando.CommandText = consulta;
                Comando.CommandType = CommandType.Text;
                SqlDataReader reader = Comando.ExecuteReader();

                if (reader.Read())
                {
                    valor_buscado = reader[columna].ToString();
                }
                reader.Close();




            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = "1 " + consulta;  //genero el valor 1 al inicio de la cadena, para reconocer el error afuera
                error = error + ex.ToString();
                valor_buscado = tratar_error(error);

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }



            return valor_buscado;

        }





        public int ver_perfil(string condiciones)
        {

            int id = 0;
            string perfil = "0";
            string consulta = "";


            consulta = "select perfil  from usuario where id=" + condiciones;


            SqlCommand Comando = new SqlCommand(consulta, conexion);



            try
            {
                conexion.Open();
                Comando.CommandText = consulta;
                Comando.CommandType = CommandType.Text;
                SqlDataReader reader = Comando.ExecuteReader();

                if (reader.Read())
                {
                    perfil = reader[0].ToString();
                }
                reader.Close();


                id = Int32.Parse(perfil);

            }

            catch (SqlException ex)
            {

                // mostrar error
                string error = ex.ToString();
                id = -1;

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }



            return id;

        }



        public string insercion_de_dataset(string tabla, ArrayList campos, ArrayList valores)
        {

            string insercion;
            DataSet table = new DataSet();
            SqlCommand Comando = conexion.CreateCommand();
            
            insercion = "INSERT  INTO " + tabla + " (" + PrintValues(campos) + ") VALUES (" + PrintValues(valores) + ")";
            
            try
            {
                conexion.Open();
                Comando.CommandText = insercion;
                Comando.ExecuteNonQuery();
            }



            catch (SqlException ex)
            {

                // mostrar error
                string error= "1 "+insercion;  //genero el valor 1 al inicio de la cadena, para reconocer el error afuera
                error = error + ex.ToString();
                insercion = tratar_error(error);
              

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            //return "proceso exitoso";
            return insercion;
        }


        public string actualizacion_de_dataset(string tabla, string id, ArrayList campos_y_valores)
        {

            string actualizacion;
            DataSet table = new DataSet();
            SqlCommand Comando = conexion.CreateCommand();

            actualizacion = "UPDATE " + tabla + " SET " + PrintValues(campos_y_valores) + " WHERE id=" + id;

            try
            {
                conexion.Open();
                Comando.CommandText = actualizacion;
                Comando.ExecuteNonQuery();
            }



            catch (SqlException ex)
            {

                // mostrar error
                string error = "1 " + actualizacion;  //genero el valor 1 al inicio de la cadena, para reconocer el error afuera
                error = error + ex.ToString();
                actualizacion = tratar_error(error);

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            //return "proceso exitoso";
            return actualizacion;
        }


        public string actualizacion_personalizada(string tabla, string id_con_condicion, ArrayList campos_y_valores)
        {

            string actualizacion;
            DataSet table = new DataSet();
            SqlCommand Comando = conexion.CreateCommand();

            actualizacion = "UPDATE " + tabla + " SET " + PrintValues(campos_y_valores) + " WHERE " + id_con_condicion;

            try
            {
                conexion.Open();
                Comando.CommandText = actualizacion;
                Comando.ExecuteNonQuery();
            }



            catch (SqlException ex)
            {

                // mostrar error
                string error = "1 " + actualizacion;  //genero el valor 1 al inicio de la cadena, para reconocer el error afuera
                error = error + ex.ToString();
                actualizacion = tratar_error(error);
               

            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            //return "proceso exitoso";
            return actualizacion;
        }










        
        public string borrado_por_tabla_e_id(string tabla, string id)
        {

            string borrado;
            
            SqlCommand Comando = conexion.CreateCommand();
            // tomo para todos las tablas el atributo id siempre 
            borrado = "DELETE FROM " + tabla + " WHERE  id=" + id + " ";

            try
            {
                conexion.Open();
                Comando.CommandText = borrado;
                Comando.ExecuteNonQuery();
            }



            catch (SqlException ex)
            {

                // mostrar error
                string error = "1 " + borrado;  //genero el valor 1 al inicio de la cadena, para reconocer el error afuera
                error = error + ex.ToString();
                borrado=tratar_error(error);


            }

            finally
            {
                // Close Connection
                conexion.Close();
            }

            //return "proceso exitoso";
            return borrado;
        }


        public string tratar_error(string resultado)
        {
            //string error = resultado.Substring(0, 1);
            string detalle = "";

           // if (error.Equals("1"))
           // {
                //ver que onda
                int desde = resultado.IndexOf("System.Data.SqlClient.SqlException", 0) + 36;
                int hasta = resultado.IndexOf("System.Data.SqlClient.SqlConnection", 0);
                hasta = hasta - desde - 4;
                detalle = resultado.Substring(desde, hasta);
                //Response.Write("<script>window.alert('Atencion Ocurrio un error');</script>");
                //Label1.Text = "Error al ejecutar la transaccion";
                //Label1.Text = detalle;
                //Label1.ForeColor = System.Drawing.Color.Red;
           // }
            //else
            //{
                //Response.Write("<script>window.alert('Bienvenido');</script>");
                //quiza un mensaje
                //Response.Redirect("login_clientes.aspx");
            //}

            return detalle;
        }



        public string[] revisar_error(string resultado, string parametro, string mensaje_exito, string mensaje_error, string pexito, string perror)
        {

            string error = resultado.Substring(0, 3);
            string[] retornar = new string[3];

            SetInitValues(retornar,3);
            string i = "<script>window.alert('";
            string f = "');</script>";

            if (!error.Equals(parametro))
            {
                //Response.Write("<script>window.alert('Atencion Ocurrio Un Error Al Intentar Ejecutar La Transaccion');</script>");
                mensaje_error = i + mensaje_error + f;
                //Label1.Text = resultado;
               retornar[0]="0";
               retornar[1] = mensaje_error;
               retornar[2] = perror;
            

            }
            else
            {

                mensaje_exito = i + mensaje_exito + f;
                retornar[0] = "1";
                retornar[1] = mensaje_exito;
                retornar[2] = pexito;
            }

            return retornar; 
        }
    }

}
