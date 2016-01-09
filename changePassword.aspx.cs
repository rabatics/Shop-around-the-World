using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class changePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void checkPassword(object sender, EventArgs e)
    {
        string id = "admin";
        string pwd = oldpwd.Text;
        int flag=0;
        int check = CatalogAccess.changePassword(pwd, id, out flag);
        // Display product details
        this.newpwd.Text += check.ToString();
    }
}