using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_BanSach.Admin
{
    public partial class DanhSachHD : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_HoaDon = new DataSet();
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                
            }
            else
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                LoadHD();
            }
        }

        private void LoadHD()
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT Order_ID, Date, Name_Received, Name_Pay, SumMoney, State FROM tbl_Order";
            SqlDataAdapter da_HoaDon = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_HoaDon.Fill(ds_HoaDon, "HoaDon");

            GridView1.DataSource = ds_HoaDon.Tables["HoaDon"];
            GridView1.DataBind();
            if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lbMa = (Label)GridView1.Rows[e.RowIndex].FindControl("Label1");
            //tbl_Order o = db.tbl_Orders.SingleOrDefault(c => c.Order_ID == lbMa.Text);

            //db.SubmitChanges();
            //LoadHD();
            Response.Redirect("ThongtinHD.aspx?Order_ID=" + lbMa.Text + "");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}