using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        int flag = 0;
        lblError.Text = "";
        int isValid = CatalogAccess.changePassword(txtPassword.Text,txtLogin.Text, out flag);

        if (isValid==1)
        {
            Session["user"] = txtLogin.Text;
            int custid = CatalogAccess.GetCustomerId(txtLogin.Text, out custid);
            Session["userid"] = custid;
            if (Session["prevpage"] != null)
            {
                string prev = (string)Session["prevpage"];
                Session.Remove("prevpage");
                Response.Redirect(prev);

            }
            else {
                Response.Redirect("Shop.aspx");
            }
           
        }
        else
        {
            lblError.Text = "Invalid Credentials";
        }

    }
}