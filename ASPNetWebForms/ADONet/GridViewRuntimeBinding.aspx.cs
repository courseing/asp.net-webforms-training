using ASPNetWebForms.DAL;
using ASPNetWebForms.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNetWebForms.ADONet
{
    public partial class GridViewRuntimeBinding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGridView();
            }
        }

        public void BindGridView()
        {
            ProductDAL product = new ProductDAL();
            gvProducts.DataSource = product.GetProducts();
            gvProducts.DataBind();
        }

        protected void gvProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProducts.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void gvProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Product product = new Product();

            GridViewRow row = gvProducts.Rows[e.RowIndex];
            product.Id = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Values[0]);
            product.Name = (row.FindControl("txtName") as TextBox).Text;

            ProductDAL productDAL = new ProductDAL();
            productDAL.UpdateProduct(product);

            gvProducts.EditIndex = -1;
            BindGridView();
        }
    }
}