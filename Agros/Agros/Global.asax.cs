﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

namespace Agros
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["pagina"] = "0";
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["usuario"] = "0";
            Session["cliente"] = "0";
            Session["perfil"] = "0";
            Session["id_factura"] = "0";
            Session["id_os"] = "0";
            Session["mensaje_exito"] = "";
            Session["mensaje_error"] = "";

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}