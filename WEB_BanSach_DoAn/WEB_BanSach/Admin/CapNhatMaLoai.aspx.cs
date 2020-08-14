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
    public partial class CapNhatMaLoai : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_TheLoai = new DataSet();
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
            cmmSELECT = "SELECT * FROM tbl_Type";
            SqlDataAdapter da_TheLoai = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_TheLoai.Fill(ds_TheLoai, "TheLoai");

            GridView1.DataSource = ds_TheLoai.Tables["TheLoai"];
            GridView1.DataBind();
            if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        void rong()
        {
            txtMa.Text = "";
            txttenML.Text = "";
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            load();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "INSERT INTO tbl_Type VALUES(N'" + txttenML.Text +"')";
            SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
            cmm.ExecuteNonQuery();

            load();
            Response.Write("<script language='javascript'>alert('" + "Thêm thành công." + "')</script>");
            rong();
            txttenML.Focus();
            if (conn.Conn.State == ConnectionState.Open)
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

            cmmSELECT = "UPDATE tbl_Type SET Type_Name = N'"+ txttenML.Text + "' WHERE Type_ID = '"+int.Parse(txtMa.Text)+"'";
            SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
            cmm.ExecuteNonQuery();

            load();
            Response.Write("<script language='javascript'>alert('" + "Sửa thành công." + "')</script>");
            rong();
            txttenML.Focus();
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

            cmmSELECT = "DELETE FROM tbl_Type WHERE Type_ID = '"+ int.Parse(txtMa.Text)+"' ";
            SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
            cmm.ExecuteNonQuery();
            load();
            Response.Write("<script language='javascript'>alert('" + "Xoá thành công." + "')</script>");
            rong();
            txttenML.Focus();
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("CapNhatMaLoai.aspx");
            txttenML.Focus();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            Label lblMa = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lbMa");
            cmmSELECT = "SELECT * FROM tbl_Type WHERE Type_ID = '"+int.Parse(lblMa.Text)+"'";
            SqlDataAdapter da_CTTheLoai = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_CTTheLoai.Fill(ds_TheLoai, "CTTheLoai");
            dt = ds_TheLoai.Tables["CTTheLoai"];

            txtMa.Text = dt.Rows[0][0].ToString();
            txttenML.Text = dt.Rows[0][1].ToString();
            GridView1.EditIndex = e.NewEditIndex;
            load();
            if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
    }
}