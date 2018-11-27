using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ASPNetWebForms.DAL;

namespace WebAuth
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!(User.IsInRole("Product Manager") || User.IsInRole("Admin")))
            //{
            //    Response.Redirect("UnAuthorized.aspx");
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ProductDAL product = new ProductDAL();
            product.InsertData();
            //product.Name = txtProductName.Text;
            //if (!product.AddRecord())
            //{
            //    Response.Write("Product could not be saved");
            //}

        }
    }
}