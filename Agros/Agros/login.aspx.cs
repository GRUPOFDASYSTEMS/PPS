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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            // the following line is important
            MasterPage master = this.Master;
            // unfortunately, compiler warns us that master is not used
            //ContentPageLabel.Text = "Hello, World!";
        }



        

        //public void verifica_login()
        //{
        //    //int a=this.Master.FindControl(verifica_login);
        //    //Console.WriteLine("Incrementada edad de trabajador");
        //}


        //public  void quita_verifica_login()
        //{
        //    //Master m = new MasterPage();
            
        //    //Console.WriteLine("Incrementada edad de trabajador");
        //}





        protected void Button1_Click(object sender, EventArgs e)
        {
            linkeo linker = new linkeo();
            string condiciones;
            int existe = 0;

            condiciones = TextBoxLogin.Text + " and password=" + TextBox2.Text;

            existe = linker.ver_perfil(condiciones);

            if (existe.Equals(0))
                Label1.Text = "Error de ingreso, compruebe su nombre de usuario y clave e intente nuevamente";
            else
            {             //existe el usuario, con lo cual lo guardo y sigo
                Label1.Text = existe.ToString();
                Session["usuario"] = TextBoxLogin.Text;
                switch (existe)
                {
                    case 1:
                        {
                            
                            Response.Redirect("indice_admin.aspx");
                            break;
                        }
                    case 2:
                        {
                            Response.Redirect("indice_administrativo.aspx");
                            break;
                        }
                    case 3:
                        {

                            Response.Redirect("indice_operario.aspx");
                            break;
                        }
                }

            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }

        
        
    }




    //public class nueva_pagina : Site11
    //{


        




    //}






}
