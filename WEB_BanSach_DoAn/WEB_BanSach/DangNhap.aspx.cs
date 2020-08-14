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
    public partial class DangNhap : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_TaiKhoan = new DataSet();
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel3.Visible = false;
            this.txtUser.Focus();
        }

        public bool KT_Account(string _tenDN, string _pass)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT COUNT(*) FROM tbl_Account WHERE Account = '"+ _tenDN +"' AND Password = '"+_pass+"'";
            SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
            int count = (int)cmm.ExecuteScalar();
            if(count>0)
            {
                return true;
            }
            return false;
            if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        public bool Check_Key(string _TenDN, string _Password)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT COUNT(*) FROM tbl_Customer Where tbl_Customer.[User] = '"+ _TenDN +"' and tbl_Customer.Password = '"+ _Password +"'";
            SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);

            int count = (int)cmm.ExecuteScalar();
            if(count>0)
            {
                return true;
            }
            return false;

            if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if(txtUser.Text == "")
            {
                Label1.Text = "User chưa nhập";
                return;
            }
            if (txtPass.Text == "")
            {
                Label1.Text = "Password chưa nhập";
                return;
            }
            if(KT_Account(txtUser.Text, txtPass.Text))
            {
                Session["UserName"] = txtUser.Text;
                Response.Redirect("~\\Admin\\NhapHang.aspx");
            }
            else
            {
                Session["UserName"] = txtUser.Text;
                if (Check_Key(txtUser.Text, txtPass.Text))
                {

                    GioHang gh = new GioHang();
                    DataTable dt = gh.GetDataTable();
                    int dem = 0;
                    if (dt.Rows.Count > 0)
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = true;
                        dem = dt.Rows.Count;
                        lblGioHang.Text = dem.ToString();
                    }
                    else
                    {
                        Panel2.Visible = true;
                        Panel1.Visible = false;
                        Panel3.Visible = false;
                    }

                    string user = Convert.ToString(Session["User"]);
                    cmmSELECT = "SELECT * FROM tbl_Customer WHERE tbl_Customer.[User]= '" + txtUser.Text + "'";
                    SqlDataAdapter da_TaiKhoan = new SqlDataAdapter(cmmSELECT, conn.Conn);
                    da_TaiKhoan.Fill(ds_TaiKhoan, "TaiKhoan");

                    DataTable dt_TaiKhoan = ds_TaiKhoan.Tables["TaiKhoan"];
                    if (dt_TaiKhoan != null)
                    {
                        Session["pass"] = dt_TaiKhoan.Rows[0][1].ToString();
                        Session["hoten"] = dt_TaiKhoan.Rows[0][2].ToString();
                        Session["email"] = dt_TaiKhoan.Rows[0][3].ToString();
                        Session["diachi"] = dt_TaiKhoan.Rows[0][4].ToString();
                        Session["SDT"] = dt_TaiKhoan.Rows[0][5].ToString();
                    }
                }
                else
                {
                    Label1.Text = "Sai Tài khoản hoặc Mật khẩu";
                }
            }
        }
    }
}