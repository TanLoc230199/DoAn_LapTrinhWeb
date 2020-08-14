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
    public partial class CapNhatNCC : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_NCC = new DataSet();
        DataTable dt;
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                load();
            if (Session["Username"] != null)
            { }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void load()
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT * FROM tbl_Supplier";
            SqlDataAdapter da_NCC = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_NCC.Fill(ds_NCC, "NCC");
            GridView1.DataSource = ds_NCC.Tables["NCC"];
            GridView1.DataBind();

            if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        void rong()
        {
            txtMa.Text = "";
            txtTenNCC.Text = "";
            txtDiachi.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
        }

        bool KT(string tensp, string diachi, string sdt)
        {
            if (tensp == "" || diachi == "" || sdt == "")
            {
                return false;
            }
            return true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            if (KT(txtTenNCC.Text, txtDiachi.Text, txtPhone.Text))
            {
                cmmSELECT = "INSERT INTO tbl_Supplier VALUES (N'"+ txtTenNCC.Text +"',N'"+ txtDiachi.Text +"','"+ int.Parse(txtPhone.Text) +"','"+ txtEmail.Text +"')";
                SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
                cmm.ExecuteNonQuery();
                load();
                Response.Write("<script language='javascript'>alert('" + "Thêm thành công." + "')</script>");
                rong();
            }
            else
            {
                Label2.Text = "Chưa nhập đủ thông tin.";
            }
            if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            if (KT(txtTenNCC.Text, txtDiachi.Text, txtPhone.Text))
            {
                cmmSELECT = "UPDATE tbl_Supplier SET Supplier_Name = N'"+ txtTenNCC.Text +"', Address = N'"+txtDiachi.Text +"', Phone = '"+int.Parse(txtPhone.Text)+"', Email= '"+ txtEmail.Text+"' WHERE Supplier_ID = '" + int.Parse(txtMa.Text) + "'";
                SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
                cmm.ExecuteNonQuery();
                load();
                Response.Write("<script language='javascript'>alert('" + "Sửa thành công." + "')</script>");
                rong();
            }
            else
            {
                Label2.Text = "Bạn chưa chọn nhà cung cấp.";
            }
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            if (KT(txtTenNCC.Text, txtDiachi.Text, txtPhone.Text))
            {
                cmmSELECT = "DELETE FROM tbl_Supplier WHERE Supplier_ID = '"+ int.Parse(txtMa.Text)+ "'";
                SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
                cmm.ExecuteNonQuery();
                load();
                Response.Write("<script language='javascript'>alert('" + "Xoá thành công." + "')</script>");
                rong();
                txtTenNCC.Focus();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('" + "Chưa chọn nhà cung cấp." + "')</script>");
            }
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            load();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            Label lblMa = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lbMa");
            cmmSELECT = "SELECT * FROM tbl_Supplier WHERE Supplier_ID = '"+ int.Parse(lblMa.Text)+"'";
            SqlDataAdapter da_NCC = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_NCC.Fill(ds_NCC, "CTNCC");
            dt = ds_NCC.Tables["CTNCC"];
            txtMa.Text = dt.Rows[0][0].ToString();
            txtTenNCC.Text = dt.Rows[0][1].ToString();
            txtDiachi.Text = dt.Rows[0][2].ToString();
            txtPhone.Text = dt.Rows[0][3].ToString();
            txtEmail.Text = dt.Rows[0][4].ToString();

            GridView1.EditIndex = e.NewEditIndex;
            load();
            Label2.Text = "";
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("CapNhatNCC.aspx");
            txtTenNCC.Focus();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}