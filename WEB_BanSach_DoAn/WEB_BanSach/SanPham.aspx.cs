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
    public partial class SanPham : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataTable dt;
        DataSet ds_SanPham = new DataSet();
        string cmmSELECT = "";
        string loai_sp;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string Type_ID = Request.QueryString["Type_ID"];
                if (Title_SanPham(Type_ID) != null)
                {
                    lblTieuDe.Text = Title_SanPham(Type_ID);

                }
                Load_SanPham();
            }

        }

        public string Title_SanPham(string Type_ID)
        {

            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            
            cmmSELECT = "SELECT Type_Name FROM tbl_Type WHERE Type_ID = '"+ Type_ID.Trim() +"'";
            SqlDataAdapter da_LoaiSanPham = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_LoaiSanPham.Fill(ds_SanPham, "LoaiSanPham");

            dt = ds_SanPham.Tables["LoaiSanPham"];
            
            loai_sp = dt.Rows[0][0].ToString();


            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            return loai_sp;
        }

        public void Load_SanPham()
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            if(ds_SanPham.Tables["LocSanPham"] != null)
            {
                ds_SanPham.Tables["LocSanPham"].Clear();

            }

             string Type_ID = Request.QueryString["Type_ID"];
             cmmSELECT = "SELECT tbl_Product.Product_ID, tbl_Product.Product_Name, Image, Price_Export FROM tbl_Product, tbl_Type WHERE tbl_Product.Type_ID = tbl_Type.Type_ID AND tbl_Type.Type_ID = '"+Type_ID.Trim()+"' ";
             SqlDataAdapter da_SanPham = new SqlDataAdapter(cmmSELECT, conn.Conn);
             da_SanPham.Fill(ds_SanPham, "LocSanPham");

            PagedDataSource pdata = new PagedDataSource();
            pdata.DataSource = ds_SanPham.Tables["LocSanPham"].DefaultView;
            pdata.PageSize = 9;
            pdata.AllowPaging = true;
            pdata.CurrentPageIndex = CurrentP;
            sanpham.DataSource = pdata;
            sanpham.DataBind();
            LbtBack.Enabled = !pdata.IsFirstPage;
            LbtNext.Enabled = !pdata.IsLastPage;
            LblPage.Text = (CurrentP + 1) + "/" + pdata.PageCount;

            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
        }
        public int CurrentP
        {
            set
            {
                this.ViewState["cp"] = value;
            }
            get
            {
                if (this.ViewState["cp"] == null)
                {
                    this.ViewState["cp"] = 0;
                    return 0;
                }
                else
                {
                    return (int)this.ViewState["cp"];
                }
            }
        }
        protected void LbtBack_Click(object sender, EventArgs e)
        {
            CurrentP -= 1;
            Load_SanPham();
        }

        protected void LbtNext_Click(object sender, EventArgs e)
        {
            CurrentP += 1;
            Load_SanPham();
        }
    }
}