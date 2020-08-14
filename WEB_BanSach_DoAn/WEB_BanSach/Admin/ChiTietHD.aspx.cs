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
    public partial class ChiTietHD : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_ChiTietHD = new DataSet();
        DataTable dt;
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }
            string maHD = Request.QueryString.Get("Order_ID");
            Label1.Text = maHD;
            load();
        }

        private void load()
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT * FROM tbl_OrderDetial WHERE Order_ID = '"+ int.Parse(Label1.Text) +"'";
            SqlDataAdapter da_ChiTietHD = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_ChiTietHD.Fill(ds_ChiTietHD, "ChiTietHD");

            GridView1.DataSource = ds_ChiTietHD.Tables["ChiTietHD"];
            GridView1.DataBind();

            if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }    
        }

        bool KTxuly()
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT State FROM tbl_Order WHERE Order_ID = '"+ int.Parse(Label1.Text) +"'";
            SqlDataAdapter da_XuLy = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_XuLy.Fill(ds_ChiTietHD, "XuLy");
            dt = ds_ChiTietHD.Tables["XuLy"];

            if(dt.Rows[0][0].ToString() == "Đã xử lý")
            {
                return false;
            }
            return true;
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        protected void btnXuly_Click(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            if (KTxuly())
            {
                dt = ds_ChiTietHD.Tables["ChiTietHD"];
                for(int i=0; i < dt.Rows.Count; i++)
                {
                    cmmSELECT = "UPDATE tbl_Product SET Amount = Amount - '"+ Convert.ToInt32(dt.Rows[i][3].ToString()) + "' WHERE Product_ID = '"+ int.Parse(dt.Rows[i][1].ToString())+ "'";
                    SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
                    cmm.ExecuteNonQuery();

                    string cmmSELECT2 = "UPDATE tbl_Order SET State = N'Đã xử lý' WHERE Order_ID = '"+ int.Parse(Label1.Text) + "'";
                    SqlCommand cmmUP = new SqlCommand(cmmSELECT2,conn.Conn);
                    cmmUP.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>alert('" + "Xử lý thành công." + "')</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('" + "Hoá đơn này đã xử lý." + "')</script>");
            }

            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}