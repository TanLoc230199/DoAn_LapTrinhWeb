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
    public partial class ChiTiet : System.Web.UI.Page
    {
        
        ConnectionString conn = new ConnectionString();
        DataSet ds_CTSP = new DataSet();
        DataTable dt;
        string cmmSELECT = "";
        bool kt = true;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(conn.Conn.State == ConnectionState.Closed)
                {
                    conn.Conn.Open();
                }
                string productID = Request.QueryString["Product_ID"];
                cmmSELECT = "SELECT Product_ID, Product_Name, tbl_Type.Type_Name, tbl_Style.Style_Name, Image, Color, Material, Size, Price_Export, Amount, tbl_Type.Type_ID FROM tbl_Product, tbl_Type, tbl_Style WHERE tbl_Product.Type_ID = tbl_Type.Type_ID and tbl_Product.Style_ID = tbl_Style.Style_ID and Product_ID = '"+ productID +"'";
                SqlDataAdapter da_CTSP = new SqlDataAdapter(cmmSELECT,conn.Conn);
                da_CTSP.Fill(ds_CTSP, "ChiTietSanPham");

                dt = ds_CTSP.Tables["ChiTietSanPham"];
                if(dt!= null)
                {
                    hdf.Value = dt.Rows[0][0].ToString();
                    lblTieuDe.Text = "Chi tiết sản phẩm: " + dt.Rows[0][1].ToString();
                    lblType_Name.Text = dt.Rows[0][2].ToString();
                    lblStyle_Name.Text = dt.Rows[0][3].ToString();
                    lblImage.ImageUrl = "~/AnhSanPham/" + dt.Rows[0][4].ToString();
                    lblColor.Text = dt.Rows[0][5].ToString();
                    lblMaterial.Text = dt.Rows[0][6].ToString();
                    lblSize.Text = dt.Rows[0][7].ToString();
                    lblPrice.Text = dt.Rows[0][8].ToString().Replace(',', '.') + " VNĐ";
                    lblSL.Text = dt.Rows[0][9].ToString();
                    txtTotal.Text = "1";
                }
                Load_SanPhamCungLoai(productID, dt.Rows[0][10].ToString());
                if (conn.Conn.State == ConnectionState.Open)
                {
                    conn.Conn.Close();
                }
            }
        }
        
        public void Load_SanPhamCungLoai(string _ProductID, string _TypeID)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT Product_ID, Product_Name, Image, Price_Export FROM tbl_Product WHERE Type_ID = '"+ _TypeID +"' AND Product_ID != '"+_ProductID +"'";
            SqlDataAdapter da_SanPhamKhac = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_SanPhamKhac.Fill(ds_CTSP, "SanPhamKhac");

            sanpham.DataSource = ds_CTSP.Tables["SanPhamKhac"];
            sanpham.DataBind();

            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        protected void CtvThongBao_ServerValidate(object source, ServerValidateEventArgs args)
        {
            kt = true;
            string chuoi = args.Value.Trim();

            if (args.Value == null || args.Value.ToString() == "") kt = false;
            for (int i = 0; i < args.Value.Length; i++)
            {
                if (args.Value[i].ToString() != "1" && args.Value[i].ToString() != "2" && args.Value[i].ToString() != "3" && args.Value[i].ToString() != "4" && args.Value[i].ToString() != "5" && args.Value[i].ToString() != "6" && args.Value[i].ToString() != "7" && args.Value[i].ToString() != "8" && args.Value[i].ToString() != "0" && args.Value[i].ToString() != "9")
                {
                    kt = false;
                    break;
                }
                else
                {
                    if (int.Parse(args.Value) == 0 || int.Parse(args.Value) > int.Parse(lblSL.Text)) kt = false;
                }
            }
            if (kt == false) args.IsValid = false;
            else args.IsValid = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            if (kt==true)
            {
                double total = 0;
                int soluong = 0;

                cmmSELECT = "SELECT Product_Name, Price_Export, Size, Color, Material, Weight, Product_ID  FROM tbl_Product WHERE Product_ID = '" + hdf.Value.ToString() + "'";
                SqlDataAdapter da_CTSP = new SqlDataAdapter(cmmSELECT,conn.Conn);
                da_CTSP.Fill(ds_CTSP, "CTSP");

                dt = ds_CTSP.Tables["CTSP"];
                if(dt !=null)
                {
                    GioHang gh = new GioHang();
                    //gh= (GioHang) Session["giohang"];
                    soluong = int.Parse(txtTotal.Text);
                    total = float.Parse(dt.Rows[0][1].ToString()) * Convert.ToDouble(txtTotal.Text.Trim());
                    gh.dienVaoBang(dt.Rows[0][0].ToString(), Convert.ToDouble(txtTotal.Text.Trim()), Convert.ToDouble(dt.Rows[0][1].ToString()), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString(), total);
                    
                    Session["giohang"] = gh;
                    DataTable tb = gh.GetDataTable();
                    
                    Response.Redirect("GioHang.aspx");
                }
                if (conn.Conn.State == ConnectionState.Open)
                {
                    conn.Conn.Close();
                }
            }
        }
    }
}