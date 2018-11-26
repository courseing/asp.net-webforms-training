using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNetWebForms
{
    public partial class ValidatorControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cstvSelectGender_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!rbtnGenderFemale.Checked && !rbtnGenderMale.Checked)
                args.IsValid = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

            }
        }
    }
}