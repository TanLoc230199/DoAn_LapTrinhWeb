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
    public partial class CapNhatHSX : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_HSX = new DataSet();
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
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            cmmSELECT = "SELECT * FROM tbl_Producer";
            SqlDataAdapter da_HSX = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_HSX.Fill(ds_HSX, "HSX");

            GridView1.DataSource = ds_HSX.Tables["HSX"];
            GridView1.DataBind();
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        void rong()
        {
            txtMa.Text = "";
            txtTen.Text = "";
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            load();
        }
        protected void btnNhap_Click(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "INSERT INTO tbl_Producer VALUES(N'" + txtTen.Text + "')";
            SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
            cmm.ExecuteNonQuery();

            load();
            Response.Write("<script language='javascript'>alert('" + "Thêm thành công." + "')</script>");
            rong();
            txtTen.Focus();
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "UPDATE tbl_Producer SET Producer_Name = N'" + txtTen.Text + "' WHERE Producer_ID = '" + int.Parse(txtMa.Text) + "'";
            SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
            cmm.ExecuteNonQuery();

            load();
            Response.Write("<script language='javascript'>alert('" + "Sửa thành công." + "')</script>");
            rong();
            txtTen.Focus();
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "DELETE FROM tbl_Producer WHERE Producer_ID = '" + int.Parse(txtMa.Text) + "' ";
            SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
            cmm.ExecuteNonQuery();
            load();
            Response.Write("<script language='javascript'>alert('" + "Xoá thành công." + "')</script>");
            rong();
            txtTen.Focus();
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("CapNhatHSX.aspx");
            txtTen.Focus();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            Label lblMa = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lbMa");
            cmmSELECT = "SELECT * FROM tbl_Producer WHERE Producer_ID = '" + int.Parse(lblMa.Text) + "'";
            SqlDataAdapter da_CTHSX = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_CTHSX.Fill(ds_HSX, "CTHSX");
            dt = ds_HSX.Tables["CTHSX"];

            txtMa.Text = dt.Rows[0][0].ToString();
            txtTen.Text = dt.Rows[0][1].ToString();
            GridView1.EditIndex = e.NewEditIndex;
            load();
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
    }
}