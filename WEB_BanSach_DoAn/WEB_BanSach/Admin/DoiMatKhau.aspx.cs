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
    public partial class DoiMatKhau : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_TaiKhoan = new DataSet();
        string cmmSELECT = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            txtTK.Text = Session["Username"].ToString();
        }

        bool KTTK(string tk, string pass)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT COUNT(*) FROM tbl_Account WHERE Account = '"+ tk +"', Password = '"+ pass +"'";
            SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
            int count = (int) cmm.ExecuteScalar();
            if(count > 0)
            {
                return true;
            }
            return false;

            if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        bool KTrong(string mkc, string mkm, string xn)
        {
            if (mkc == "" || mkm == "" || xn == "")
            {
                return false;
            }
            return true;
        }
        protected void btnDoi_Click(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            if (KTrong(txtMKcu.Text, txtMKM.Text, txtXN.Text))
            {
                if (KTTK(txtTK.Text, txtMKcu.Text) == true)
                {
                    if (txtMKM.Text == txtXN.Text)
                    {
                        cmmSELECT = "UPDATE tbl_Account SET Passwor = '"+ txtMKM.Text +"' WHERE Account = '" + txtTK.Text + "'";
                        SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
                        cmm.ExecuteNonQuery();

                        Response.Write("<script language='javascript'>alert('" + "Đổi mật khẩu thành công" + "')</script>");
                        //Response.Redirect("Nhaphang.aspx");
                    }
                    else
                    {
                        Label1.Text = "Hai mật khẩu khác nhau.";
                    }
                }
                else
                {
                    Label1.Text = "Mật khẩu không đúng";
                }
            }
            else
            {
                Label1.Text = "Bạn chưa nhập đủ thông tin.";
            }
                
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
    }
}