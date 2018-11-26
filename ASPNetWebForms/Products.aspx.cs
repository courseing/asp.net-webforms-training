//using ASPNetWebForms.Model;
using DAL;
using ExternalDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNetWebForms
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string ApplicationStatus = Application["Status"].ToString();
            Response.Write(ApplicationStatus);

            //string Id = Request.QueryString["Id"].ToString();
            //Response.Write(Id);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Category cat = new Category();

            Product prd = new Product();
            prd.Name = "";
            prd.Id = 1;

            Session["ProductName"] = txtName.Text;
            Session["ProductPrice"] = txtPrice.Text;
            if (Session["TotalAmount"] != null)
                Session["TotalAmount"] = Convert.ToInt32(Session["TotalAmount"].ToString()) + Convert.ToInt32(txtPrice.Text);
            else
                Session["TotalAmount"] = Convert.ToInt32(txtPrice.Text);

            Response.Cookies["ProductName"].Value = txtName.Text;

        }
    }
}