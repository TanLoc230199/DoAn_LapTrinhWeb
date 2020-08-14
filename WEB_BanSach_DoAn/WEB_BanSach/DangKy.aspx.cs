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
    public partial class DangKy : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        string cmmSELECT = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            txtTendaydu.Focus();
            Label1.Text = "";
        }

        private bool KiemTra(string _user)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT COUNT(*) FROM tbl_Customer WHERE [User] = '"+_user+"' ";
            SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);

            int count = (int)cmm.ExecuteScalar();
            if(count > 0)
            {
                return true;
            }
            
            return false;
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public string getDiaChi()
        {
            string diachi = "";
            if (txtDiachi.Text != "")
            {
                diachi = diachi + txtDiachi.Text;
            }
            if (txtQuanHuyen.Text != "")
            {
                diachi = diachi + "-" + txtQuanHuyen.Text;
            }
            if (txtTinhThanh.Text != "")
            {
                diachi = diachi + "-" + txtTinhThanh.Text;
            }
            if (txtQuocGia.Text != "")
            { 
                diachi = diachi + "-" + txtQuocGia.Text;
            }
            return diachi;
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            if (txtUser.Text == "" || txtPass.Text == "" || RePass.Text == "")
            {
                Label1.Text = "Bạn chưa nhập đầy đủ thông tin";
            }
            else
            {
                if (KiemTra(txtUser.Text))
                {
                    Label1.Text = "Tên đăng nhập đã được sử dụng";
                }
                else
                {
                    cmmSELECT = "INSERT INTO tbl_Customer VALUES(N'"+ txtUser.Text + "','"+ txtPass.Text + "',N'"+ txtTendaydu.Text + "',N'"+ txtEmail.Text +"',N'"+ getDiaChi() +"','"+int.Parse(txtSDT.Text)+"')";
                    SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
                    cmm.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>alert('" + "Đăng ký thành công" + "')</script>");
                    Response.Redirect("DangNhap.aspx?");
                }
            }
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
    }
}