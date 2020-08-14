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
    public partial class ThongTinHD : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_ChiTietHD = new DataSet();
        DataTable dt;
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            Label1.Text = Request.QueryString["Order_ID"];
            cmmSELECT = "SELECT  Order_ID, User, Date, Pay_ID, Transport_ID, Name_Received, Address_Received, Phone_Received, Name_Pay, Address_Pay, Phone_Pay, Mesage, VAT_Gift, SumWeight, VAT_Transport, SumMoney, State FROM tbl_Order WHERE Order_ID = '"+ Label1.Text +"'";
            SqlDataAdapter da_ChiTietHD = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_ChiTietHD.Fill(ds_ChiTietHD, "ChiTietHD");
            dt = ds_ChiTietHD.Tables["ChiTietHD"];

            Label2.Text = dt.Rows[0][1].ToString();
            Label3.Text = dt.Rows[0][2].ToString();
            Label4.Text = dt.Rows[0][3].ToString();
            Label5.Text = dt.Rows[0][4].ToString();
            Label6.Text = dt.Rows[0][5].ToString();
            Label7.Text = dt.Rows[0][6].ToString();
            Label8.Text = dt.Rows[0][7].ToString();
            Label9.Text = dt.Rows[0][8].ToString();
            Label10.Text = dt.Rows[0][9].ToString();
            Label11.Text = dt.Rows[0][10].ToString();
            Label12.Text = dt.Rows[0][11].ToString();
            Label13.Text = dt.Rows[0][12].ToString();
            Label14.Text = dt.Rows[0][13].ToString();
            Label15.Text = dt.Rows[0][14].ToString();
            Label16.Text = dt.Rows[0][15].ToString();
            Label17.Text = dt.Rows[0][16].ToString();
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhSachHD.aspx");
        }
    }
}