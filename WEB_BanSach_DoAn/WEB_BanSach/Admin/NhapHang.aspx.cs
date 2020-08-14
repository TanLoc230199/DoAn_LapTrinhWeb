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
    public partial class NhapHang : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_NhapHang = new DataSet();
        DataTable dt;
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_GridViewNhapHang();
            Load_drNhanVien();
        }
        
        public void Load_drNhanVien()
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            if(Session["UserName"] != null)
            {
                cmmSELECT = "SELECT tbl_Employee.EmployeeID, tbl_Employee.EmployeeName FROM tbl_Employee, tbl_Account WHERE tbl_Employee.EmployeeID = tbl_Account.EmployeeID AND tbl_Account.Account = N'" + Session["UserName"].ToString() + "' ";
                SqlDataAdapter da_NhanVien = new SqlDataAdapter(cmmSELECT, conn.Conn);
                da_NhanVien.Fill(ds_NhapHang, "NhanVien");

                drNhanvien.DataSource = ds_NhapHang.Tables["NhanVien"];
                drNhanvien.DataValueField = "EmployeeID";
                drNhanvien.DataTextField = "EmployeeName";
                drNhanvien.DataBind();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        public void Load_GridViewNhapHang()
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            
            cmmSELECT = "SELECT * FROM tbl_Import";
            SqlDataAdapter da_NhapHang = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_NhapHang.Fill(ds_NhapHang, "NhapHang");

            GridView1.DataSource = ds_NhapHang.Tables["NhapHang"];
            GridView1.DataBind();
            if (ds_NhapHang.Tables["NhapHang"].Rows.Count > 0)
            {
                ds_NhapHang.Tables["NhapHang"].Clear();
            }
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        public void Clear_TextBox()
        {
            txtMa.Text = "";
            txtNgay.Text = "";
            //txtNhanvien.Text = "";
            //DropDownList1.Text = "";
        }

        public bool KiemTraMa(string _ma)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT COUNT(*) FROM tbl_Import  WHERE Import_ID = '"+int.Parse(txtMa.Text)+"'";
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
        protected void btnNhap_Click(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
           
            cmmSELECT = "INSERT INTO tbl_Import VALUES ('"+drNhanvien.SelectedValue.ToString()+"','"+Calendar1.SelectedDate.ToString()+"','0','"+DropDownList1.SelectedValue.ToString()+"')";
            SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
            cmm.ExecuteNonQuery();

            Load_GridViewNhapHang();
            Response.Write("<script language='javascript'>alert('" + "Nhập thành công." + "')</script>");
            Clear_TextBox();
            txtNgay.Focus();
            Response.Redirect("NhapHang.aspx");
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void btnSua_Click1(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "UPDATE tbl_Import SET EmployeeID = '"+drNhanvien.SelectedValue.ToString()+"', Date = '"+txtNgay.Text+"', Supplier_ID = '"+DropDownList1.SelectedValue.ToString()+"' WHERE Import_ID = '"+int.Parse(txtMa.Text)+"'";
            SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
            cmm.ExecuteNonQuery();
            Load_GridViewNhapHang();
            Clear_TextBox();
            Response.Write("<script language='javascript'>alert('" + "Sửa thành công." + "')</script>");
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void btnXoa_Click1(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            if (!KiemTraMa(txtMa.Text))
            {
                cmmSELECT = "DELETE FROM tbl_Import WHERE Import_ID = '" + int.Parse(txtMa.Text) + "'";
                SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
                cmm.ExecuteNonQuery();
                Response.Write("<script language='javascript'>alert('" + "Xoá thành công." + "')</script>");
                txtNgay.Focus();
                Clear_TextBox();
                Load_GridViewNhapHang();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('" + "Không xoá được." + "')</script>");
            }

            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Load_GridViewNhapHang();
        }

        protected void txtNgay_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LKChitiet_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChiTietNhap.aspx");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("NhapHang.aspx");
            txtNgay.Focus();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            Label lbMa = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lbMa");
            cmmSELECT = "SELECT * FROM tbl_Import WHERE Import_ID = '"+int.Parse(lbMa.Text)+"'";
            SqlDataAdapter da_SELECT = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_SELECT.Fill(ds_NhapHang, "SELECTED");

            dt = ds_NhapHang.Tables["SELECTED"];

            txtMa.Text = dt.Rows[0][0].ToString();
            drNhanvien.SelectedValue = dt.Rows[0][1].ToString();
            txtNgay.Text = dt.Rows[0][2].ToString();
            DropDownList1.SelectedValue = dt.Rows[0][4].ToString();

           GridView1.EditIndex = e.NewEditIndex;
            Load_GridViewNhapHang();
            Label1.Text = "";
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }   
    }
}