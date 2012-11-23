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
    public partial class Site11 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //pagina p = new pagina();
            
            //verifica_login(); 
            //nueva_pagina np = new nueva_pagina();
            //np.verifica_login();
        }




        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnPreInit(e);
        //    // the following line is important
        //    MasterPage master = this.Master;
        //    // unfortunately, compiler warns us that master is not used
        //    ContentPageLabel.Text = "Hello, World!";
        //}




    }


    

    //interface  pagina
    //{

    //    void verifica_login();
        


    //}



    //public class paginas : pagina
    //{
    //    public void verifica_login()
    //    {
    //        if (Session["usuario"].Equals("0"))
    //            Response.Redirect("login.aspx");
    //    }
    //}







    public class nueva_pagina : Site11
    {


        public virtual void verifica_login()
        {

            // if (!this.Label1.Text.Equals("~"))

            ContentPlaceHolder mpContentPlaceHolder;
            TextBox mpTextBox;
            mpContentPlaceHolder =
              (ContentPlaceHolder)Master.FindControl("Content1");
            if (mpContentPlaceHolder != null)
            {
                mpTextBox =
                    (TextBox)mpContentPlaceHolder.FindControl("TextBoxLogin");
                if (mpTextBox != null)
                {
                    // mpTextBox.Text = "TextBox found!";
                }
                else
                {

                    if (Session["usuario"].Equals("0"))
                        Response.Redirect("login.aspx");

                }



            }






        }



    }








}


 

