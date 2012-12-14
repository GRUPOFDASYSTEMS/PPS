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

namespace IU.Controles
{
    public partial class ControlNum : System.Web.UI.UserControl
    {
        public String Valor
        {
            get
            {
                return this.txtIn.Text;
            }
            set { this.txtIn.Text = value; }
        }

        public String Mensaje
        {
            get
            {
                return this.rfvError.ErrorMessage;
            }
            set { this.rfvError.ErrorMessage = value; }
        }

        public String Validacion
        {
            get
            {
                return this.rfvError.ValidationGroup;
            }
            set { this.rfvError.ValidationGroup = value; }
        }

        public String Validacion2
        {
            get
            {
                return this.rvError.ValidationGroup;
            }
            set { this.rvError.ValidationGroup = value; }
        }


        public String Validacion3
        {
            get
            {
                return this.REVError.ValidationGroup;
            }
            set { this.REVError.ValidationGroup = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Validacion = "ValidaDatos";
            Validacion2 = "ValidaDatos";
            Validacion3 = "ValidaDatos";
        }
    }
}