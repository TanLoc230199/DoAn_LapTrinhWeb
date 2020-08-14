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
    public partial class ThemTaiKhoan : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_TaiKhoan = new DataSet();
        DataTable dt;
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load();
                
                Load_drNhanVien();

            }
            txtPass.Text = "123456";
            if (Session["Username"] != null)
            {
                if(!KT_Admin())
                {
                    Response.Write("<script language='javascript'>alert('" + "Bạn không có quyền vào trang này" + "')</script>");
                    Response.Redirect("NhapHang.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            cb1.Enabled = true;
            cb2.Enabled = true;
            cb3.Enabled = false;
        }
        public bool KT_Admin()
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT Power FROM tbl_Account WHERE Account = '"+ Session["Username"].ToString() + "'";
            SqlDataAdapter da_Admin = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_Admin.Fill(ds_TaiKhoan, "Admin");
            dt = ds_TaiKhoan.Tables["Admin"];

            if(dt.Rows[0][0].ToString() == "Nhân viên")
            {
                return false;
            }
            return true;
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        public void Load_drNhanVien()
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "select EmployeeID,EmployeeName from tbl_Employee where EmployeeID not in (select EmployeeID from tbl_Account)";
            SqlDataAdapter da_NhanVien = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_NhanVien.Fill(ds_TaiKhoan, "NhanVien");

            drNhanvien.DataSource = ds_TaiKhoan.Tables["NhanVien"];
            drNhanvien.DataValueField = "EmployeeID";
            drNhanvien.DataTextField = "EmployeeName";
            drNhanvien.DataBind();

            if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        private void load()
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT * FROM tbl_Account";
            SqlDataAdapter da_TaiKhoan = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_TaiKhoan.Fill(ds_TaiKhoan, "TaiKhoan");

            GridView1.DataSource = ds_TaiKhoan.Tables["TaiKhoan"];
            GridView1.DataBind();

            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        void rong()
        {
            Load_drNhanVien();
            txtTaikhoan.Text = "";
            txtPass.Text = "123456";
            cb1.Enabled = false;
            cb2.Enabled = false;
            cb3.Enabled = false;
        }

        private bool KiemTraTK(string tk)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT COUNT(*) FROM tbl_Account WHERE Account = '"+ tk +"'";
            SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
            int count = (int)cmm.ExecuteScalar();

            if(count >0)
            {
                return false;
            }
            return true;

            if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        private bool KiemTra(string ma)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT COUNT(*) FROM tbl_Account WHERE EmployeeID = '" + int.Parse(ma) + "'";
            SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
            int count = (int)cmm.ExecuteScalar();

            if (count > 0)
            {
                return false;
            }
            return true;

            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        private bool Kiemtrarong(string tk, string mk)
        {
            if (tk == "" || mk == "")
            {
                return false;
            }
            return true;
        }


        public string getPower()
        {
            if (DropDownList1.SelectedValue == "1")
            {
                return  "Nhân viên";
            }
            if (DropDownList1.SelectedValue == "2")
            {
                return "Quản lý";
            }
            return "";
        }
        protected void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            Label lbTK = (Label)GridView1.Rows[e.RowIndex].FindControl("lbTK");
            cmmSELECT = "DELETE FROM tbl_Account WHERE Account = '" + lbTK.Text +"'";
            SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
            cmm.ExecuteNonQuery();
            
            load();
            Response.Write("<script language='javascript'>alert('" + "Xoá thành công" + "')</script>");
            txtTaikhoan.Focus();
            Label1.Text = "";

            Load_drNhanVien();
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
        }
        protected void btnMoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThemTaiKhoan.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "0")
            {
                cb1.Enabled = false;
                cb2.Enabled = false;
                cb3.Enabled = false;
            }
            if (DropDownList1.SelectedValue == "1")
            {
                cb1.Enabled = true;
                cb1.Items[0].Selected = true;
                cb1.Items[1].Selected = true;
                cb1.Items[2].Selected = true;
                cb1.Items[3].Selected = true;
                cb1.Items[4].Selected = true;
                cb1.Items[5].Selected = true;
                cb2.Enabled = true;
                cb2.Items[0].Selected = true;
                cb2.Items[1].Selected = true;
                cb2.Items[2].Selected = true;
                cb2.Items[3].Selected = true;
                cb2.Items[4].Selected = true;
                cb2.Items[5].Selected = true;
                cb3.Enabled = false;
            }
            if (DropDownList1.SelectedValue == "2")
            {
                cb1.Enabled = true;
                cb1.Items[0].Selected = true;
                cb1.Items[1].Selected = true;
                cb1.Items[2].Selected = true;
                cb1.Items[3].Selected = true;
                cb1.Items[4].Selected = true;
                cb1.Items[5].Selected = true;
                cb2.Enabled = true;
                cb2.Items[0].Selected = true;
                cb2.Items[1].Selected = true;
                cb2.Items[2].Selected = true;
                cb2.Items[3].Selected = true;
                cb2.Items[4].Selected = true;
                cb2.Items[5].Selected = true;
                cb3.Enabled = true;
                cb3.Items[0].Selected = true;
                cb3.Items[1].Selected = true;
                cb3.Items[2].Selected = true;
                cb3.Items[3].Selected = true;
                cb3.Items[4].Selected = true;
                cb3.Items[5].Selected = true;
            }
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            if (KiemTra(drNhanvien.SelectedValue.ToString()))
            {
                if (KiemTraTK(txtTaikhoan.Text))
                {
                    if (Kiemtrarong(txtTaikhoan.Text, txtPass.Text) == true)
                    {
                        cmmSELECT = "INSERT INTO tbl_Account VALUES ('" + txtTaikhoan.Text + "','" + txtPass.Text + "',N'" + getPower() + "','" + int.Parse(drNhanvien.SelectedValue.ToString()) + "')";
                        SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
                        cmm.ExecuteNonQuery();
                        load();
                        Response.Write("<script language='javascript'>alert('" + "Thêm thành công" + "')</script>");
                        // Label1.Text = "Thêm thành công";
                        Label3.Text = "";
                        rong();
                    }
                    else
                    {
                        Label1.Text = "Chưa nhập tài khoản hoặc mật khẩu.";
                        Label3.Text = "";
                    }
                }
                else
                {
                    Label3.Text = "Tài khoản này đã tồn tại.";
                    txtTaikhoan.Focus();
                }
            }
            else
            {
                Label3.Text = "Nhân viên này đã có tài khoản.";
                txtTaikhoan.Focus();
            }
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
        }
    }
}