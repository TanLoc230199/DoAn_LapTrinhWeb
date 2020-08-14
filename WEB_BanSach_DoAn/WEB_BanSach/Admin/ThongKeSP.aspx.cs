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
    public partial class ThongKeSP : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_SanPham = new DataSet();
        DataTable dt;
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadDG(DropDownList1.SelectedValue.ToString());
            if (Session["Username"] != null)
            { }
            else
                Response.Redirect("Login.aspx");
        }

        private void LoadDG(string _MaSP)
        {
           if(conn.Conn.State == ConnectionState.Closed)
           {
               conn.Conn.Open();
           }

            cmmSELECT = "SELECT Product_ID, Product_Name, Type_Name, Style_Name, Supplier_Name, Producer_Name, Price_Import, Price_Export, Amount  FROM tbl_Product, tbl_Supplier, tbl_Type, tbl_Producer, tbl_Style WHERE tbl_Product.Supplier_ID = tbl_Supplier.Supplier_ID AND tbl_Product.Style_ID = tbl_Style.Style_ID AND tbl_Product.Producer_ID = tbl_Producer.Producer_ID AND tbl_Product.Type_ID = tbl_Type.Type_ID AND tbl_Product.Type_ID = '" + int.Parse(_MaSP) + "'";
            SqlDataAdapter da_SanPham = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_SanPham.Fill(ds_SanPham, "SanPham");

            GridView1.DataSource = ds_SanPham.Tables["SanPham"];
            GridView1.DataBind();


           if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        void tinh()
        {

            //var a = (from s in db.tbl_Products
            //         select s.Product_ID).Count();
            //Label3.Text = a.ToString("###,###");
            //var b = (from s in db.tbl_Products
            //         select s.Amount).Sum();
            //Label5.Text = b.ToString();
            //var c = (from s in db.tbl_Products
            //         select s.Price_Import).Sum();
            //Label2.Text = c.ToString().Replace(',', '.');
        }
        protected void DropDownList1_PreRender(object sender, EventArgs e)
        {
            //DropDownList1.Items.Insert(0, "-----Chọn loại sản phẩm-----");
        }

        protected void btnThongke_Click(object sender, EventArgs e)
        {
            //var a = db.ThongkeSP(DropDownList1.Text);
            //GridView1.DataSource = a;
            //GridView1.DataBind();
            //tinhloai();

            LoadDG(DropDownList1.SelectedValue.ToString());
            tinhloai();
        }

        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadDG(DropDownList1.SelectedValue.ToString());
        }

        void tinhloai()
        {
            Label3.Text = GridView1.Rows.Count.ToString();
            double tongsoluong = 0;
            double tongtiennhap = 0;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                tongsoluong += double.Parse(gr.Cells[8].Text);
                tongtiennhap += double.Parse(gr.Cells[6].Text);
            }
            Label5.Text = tongsoluong.ToString("###,###");
            Label2.Text = tongtiennhap.ToString("###,###") + "  ";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}