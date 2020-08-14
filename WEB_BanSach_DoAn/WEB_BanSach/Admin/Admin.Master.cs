using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_BanSach.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            
            Literal1.Text = "Xin chào: " + Session["UserName"].ToString();
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("~/TrangChu.aspx");
        }
    }
}