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
    public partial class DangKy : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            txtTen.Focus();
            if(!IsPostBack)
            {

            }
        }


        public bool KT_TextBox(string _ten, string _dc, string _sdt)
        {
            if(_ten == "" || _dc =="" || _sdt=="")
            {
                return false;
            }
            return true;
        }

        public bool KT_Email(string _email)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT COUNT(*) FROM tbl_Employee WHERE Email = '"+_email+"'";
            SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);

            int count = (int)cmm.ExecuteScalar();
            if(count>0)
            {
                return false;
            }
            return true;

            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }


        protected void btnDangki_Click(object sender, EventArgs e)
        {
            if(KT_TextBox(txtTen.Text, txtDiachi.Text, txtSDT.Text))
            {
                if(KT_Email(txtEmail.Text))
                {
                    if(conn.Conn.State == ConnectionState.Closed)
                    {
                        conn.Conn.Open();
                    }
                    cmmSELECT = "INSERT INTO tbl_Employee VALUES (N'" + txtTen.Text + "',N'" + txtNgay.SelectedDate.ToString() + "',N'" + DropDownList1.SelectedValue.ToString() + "',N'" + txtDiachi.Text + "',N'" + txtEmail.Text + "',N'" + txtSDT.Text + "')";
                    SqlCommand cmmINSERT = new SqlCommand(cmmSELECT,conn.Conn);
                    cmmINSERT.ExecuteNonQuery();

                    Response.Write("<script language='javascript'>alert('" + "Đăng kí thành công" + "')</script>");
                    if (conn.Conn.State == ConnectionState.Open)
                    {
                        conn.Conn.Close();
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('" + "Email này đã tồn tại" + "')</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('" + "Bạn nhập thiếu thông tin." + "')</script>");
            }
        }
    }
}