using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_BanSach
{
    public partial class TrangChu : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        string cmmSELECT = "";
        DataSet ds_SachMoi = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            this.Title = "Sách Online Lộc";
            if(!IsPostBack)
            {
                string productID = Request.QueryString["Product_ID"];
                Load_Item();
            }
        }

        public void Load_Item()
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            cmmSELECT = "SELECT TOP 3 tbl_Product.Product_ID, Product_Name, Image, Price_Export FROM tbl_Import, tbl_Product, tbl_ImportDetail WHERE tbl_Import.Import_ID = tbl_ImportDetail.Import_ID and tbl_Product.Product_ID = tbl_ImportDetail.Product_ID order by tbl_Import.Date DESC;";
            SqlDataAdapter da_SachMoi = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_SachMoi.Fill(ds_SachMoi, "SachMoi");

            sanpham.DataSource = ds_SachMoi.Tables["SachMoi"];
            sanpham.DataBind();
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
        }

        protected void sanpham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}