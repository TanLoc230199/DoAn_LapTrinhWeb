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
    public partial class HangMoiVe : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_HangMoi = new DataSet();
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            phantrang();
        }

        public void phantrang()
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT TOP 15 tbl_Product.Product_ID, Product_Name, Image, Price_Export FROM tbl_Import, tbl_Product, tbl_ImportDetail WHERE tbl_Import.Import_ID = tbl_ImportDetail.Import_ID and tbl_Product.Product_ID = tbl_ImportDetail.Product_ID order by tbl_Import.Date DESC;";
            SqlDataAdapter da_HangMoi = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_HangMoi.Fill(ds_HangMoi, "HangMoi");

            PagedDataSource pdata = new PagedDataSource();
            pdata.DataSource = ds_HangMoi.Tables["HangMoi"].DefaultView;
            pdata.PageSize = 9;
            pdata.AllowPaging = true;
            pdata.CurrentPageIndex = CurrentP;
            sanphammoi.DataSource = pdata;
            sanphammoi.DataBind();
            LbtBack.Enabled = !pdata.IsFirstPage;
            LbtNext.Enabled = !pdata.IsLastPage;
            LblPage.Text = (CurrentP + 1) + "/" + pdata.PageCount;

            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
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
            phantrang();
        }

        protected void LbtNext_Click(object sender, EventArgs e)
        {
            CurrentP += 1;
            phantrang();
            //Download source code FREE tai Sharecode.vn
        }

        protected void sanphammoi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}