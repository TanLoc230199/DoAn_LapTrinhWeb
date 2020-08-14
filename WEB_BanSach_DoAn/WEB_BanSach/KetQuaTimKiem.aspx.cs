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
    public partial class KetQuaTimKiem : System.Web.UI.Page
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
                lblTieuDe.Text = "Kết quả tìm kiếm";
                Load_SanPham();
            }
            
        }

        //public string Title_SanPham(string Type_ID)
        //{

        //    if (conn.Conn.State == ConnectionState.Closed)
        //    {
        //        conn.Conn.Open();
        //    }

        //    cmmSELECT = "SELECT Type_Name FROM tbl_Type WHERE Type_ID = '" + Type_ID.Trim() + "'";
        //    SqlDataAdapter da_LoaiSanPham = new SqlDataAdapter(cmmSELECT, conn.Conn);
        //    da_LoaiSanPham.Fill(ds_SanPham, "LoaiSanPham");

        //    dt = ds_SanPham.Tables["LoaiSanPham"];
        //    loai_sp = dt.Rows[0][0].ToString();


        //    if (conn.Conn.State == ConnectionState.Closed)
        //    {
        //        conn.Conn.Open();
        //    }
        //    return loai_sp;
        //}

        public void Load_SanPham()
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            if (ds_SanPham.Tables["TimKiemSanPham"] != null)
            {
                ds_SanPham.Tables["TimKiemSanPham"].Clear();

            }

            string dieukien = Convert.ToString(Request.QueryString["DieuKien"]);
            cmmSELECT = "SELECT tbl_Type.*,tbl_Product.*,tbl_Producer.* FROM tbl_Type,tbl_Product,tbl_Producer where tbl_Type.Type_ID=tbl_Product.Type_ID and tbl_Product.Producer_ID=tbl_Producer.Producer_ID and" + dieukien;
            SqlDataAdapter da_SanPham = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_SanPham.Fill(ds_SanPham, "TimKiemSanPham");

            PagedDataSource pdata = new PagedDataSource();
            pdata.DataSource = ds_SanPham.Tables["TimKiemSanPham"].DefaultView;
            pdata.PageSize = 9;
            pdata.AllowPaging = true;
            pdata.CurrentPageIndex = CurrentP;
            TimKiem.DataSource = pdata;
            TimKiem.DataBind();
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