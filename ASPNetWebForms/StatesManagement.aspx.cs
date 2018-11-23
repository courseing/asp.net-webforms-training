using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNetWebForms
{
    public partial class SessionState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveTotal_Click(object sender, EventArgs e)
        {
            Session["ShoppingCartTotal"] = txtTotal.Text;
            Response.Cookies["ShoppingCartTotal"].Value = txtTotal.Text;
        }
    }
}