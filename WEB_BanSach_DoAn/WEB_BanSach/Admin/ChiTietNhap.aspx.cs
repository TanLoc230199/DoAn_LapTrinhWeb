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
    public partial class ChiTietNhap : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_ChiTiet = new DataSet();
        DataTable dt;
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

                if (Session["Username"] != null)
                { }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            string maHD = Request.QueryString.Get("Import_ID");
            Label7.Text = maHD;
            load();
            tinh();

        }

        void tinh()
        {
            Label1.Text = GridView1.Rows.Count.ToString();
            double tongsoluong = 0;
            double tongtiennhap = 0;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                tongsoluong += double.Parse(gr.Cells[3].Text);
                tongtiennhap += double.Parse(gr.Cells[4].Text);
            }
            Label2.Text = tongsoluong.ToString("###,###");
            Label3.Text = tongtiennhap.ToString("###,###") + "  " + "VNĐ";
        }
        
        private void load()
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }


            cmmSELECT = "SELECT * FROM tbl_ImportDetail WHERE Import_ID = '"+int.Parse(Label7.Text)+"'";
            SqlDataAdapter da_ChiTiet = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_ChiTiet.Fill(ds_ChiTiet, "ChiTiet");

            GridView1.DataSource = ds_ChiTiet.Tables["ChiTiet"];
            GridView1.DataBind();
            if (ds_ChiTiet.Tables["ChiTiet"].Rows.Count > 0)
            {
                ds_ChiTiet.Tables["ChiTiet"].Clear();
            }
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
            
        }

        void rong()
        {
            //txtMahoadon.Text = "";
            txtSL.Text = "";
            txtThanhtien.Text = "";
            Label8.Text = "";
            Label4.Text = "";
            Label6.Text = "";
        }

        protected void txtSL_TextChanged(object sender, EventArgs e)
        {
            int thanhtien = int.Parse(DropDownList3.Text) * int.Parse(txtSL.Text);
            txtThanhtien.Text = thanhtien.ToString();
        }

        bool KTMaSP(string ma, string _maSP)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT Count(*) FROM tbl_ImportDetail WHERE Import_ID = '"+ma+"' AND Product_ID = '"+_maSP+"'";
            SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);

            int count = (int)cmm.ExecuteScalar();
            if(count >0)
            {
                return false;
            }
            return true;


            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
            
        }

        bool KTSoluong(string sl)
        {
            if (txtSL.Text == "")
            {
                return false;
            }
            return true;
        }

        protected void btnNhap_Click(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            if (KTMaSP(Label7.Text, DropDownList2.SelectedValue.ToString()) && KTSoluong(txtSL.Text))
            {
                if (KTSoluong(txtSL.Text))
                {
                    cmmSELECT = "INSERT INTO tbl_ImportDetail VALUES('" + int.Parse(Label7.Text) + "','" + int.Parse(DropDownList2.SelectedValue.ToString()) + "','" + double.Parse(DropDownList3.Text) + "','" + int.Parse(txtSL.Text) + "','" + double.Parse(txtThanhtien.Text) + "')";
                    SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
                    cmm.ExecuteNonQuery();

                    string cmmUPDATE = "UPDATE tbl_Product SET Amount += '" + int.Parse(txtSL.Text) + "' WHERE Product_ID = '"+ DropDownList2.SelectedValue.ToString() +"'";
                    SqlCommand cmmUP = new SqlCommand(cmmUPDATE,conn.Conn);
                    cmmUP.ExecuteNonQuery();
                    load();
                    Response.Write("<script language='javascript'>alert('" + "Nhập thành công." + "')</script>");
                    tinh();

                }
                else
                {
                    Response.Write("<script language='javascript'>alert('" + "Bạn chưa nhập số lượng." + "')</script>");
                }
            }
            else
            {
                Label4.Text = "Sản phẩm này đã tồn tại.Bạn chỉ được sửa Số lượng.";    
            }
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            string SLCu = txtSL.Text;
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            if (KTMaSP(Label7.Text, DropDownList2.SelectedValue.ToString()) == false)
            {
                cmmSELECT = "UPDATE tbl_ImportDetail SET Product_ID = '"+ DropDownList2.SelectedValue.ToString()+ "', Price_Import = '"+DropDownList3.SelectedValue.ToString()+ "', Amount = '"+ int.Parse(txtSL.Text)+"', Money = '"+ double.Parse(txtThanhtien.Text)+ "' WHERE Import_ID = '"+ int.Parse(Label7.Text) + "' AND Product_ID = '"+ DropDownList2.SelectedValue.ToString()+"'";
                SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
                cmm.ExecuteNonQuery();

                string cmmUPDATE = "UPDATE tbl_Product SET Amount = Amount - '" + int.Parse(SLCu.ToString()) + "' + '" + int.Parse(txtSL.Text) + "'";
                SqlCommand cmmUP = new SqlCommand(cmmUPDATE,conn.Conn);
                cmmUP.ExecuteNonQuery();

                load();
                rong();
                Response.Write("<script language='javascript'>alert('" + "Sửa thành công." + "')</script>");
                Label4.Text = "";
                tinh();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('" + "Sản phẩm  này không có trong hoá đơn." + "')</script>");
                txtThanhtien.Text = "";
            }
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
            if (KTMaSP(Label7.Text, DropDownList2.SelectedValue.ToString()) == false)
            {

                cmmSELECT = "DELETE FROM tbl_ImportDetail WHERE Import_ID = '"+ int.Parse(Label7.Text) + "' AND Product_ID = '"+DropDownList2.SelectedValue.ToString() +"'";
                SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
                cmm.ExecuteNonQuery();
                load();
                rong();
                Response.Write("<script language='javascript'>alert('" + "Xoá thành công." + "')</script>");
                tinh();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('" + "Sản phẩm này không có trong hoá đơn." + "')</script>");
            }

            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void DropDownList3_TextChanged(object sender, EventArgs e)
        {
            int thanhtien = int.Parse(DropDownList3.Text) * int.Parse(txtSL.Text);
            txtThanhtien.Text = thanhtien.ToString();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var a = from s in db.tbl_ImportDetails
            //        where s.Import_ID == int.Parse(Label7.Text) && s.Product_ID == int.Parse(DropDownList2.Text)
            //        select new { s.Amount };
            //foreach (var item in a)
            //{
            //    txtSL.Text = item.Amount.ToString();
            //}
            //Label4.Text = "";
            //Label8.Text = "";
            //// txtSL.Text = "";
            //Label6.Text = "";
            //txtThanhtien.Text = "";
        }

        protected void btntiep_Click(object sender, EventArgs e)
        {
            rong();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("ChiTietNhap.aspx");
            DropDownList2.Focus();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            Label lblMa = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lbMaSP");
            cmmSELECT = "SELECT * FROM tbl_ImportDetail WHERE Product_ID = '"+ int.Parse(lblMa.Text) + "' AND Import_ID = '"+Label7.Text+"'";
            SqlDataAdapter da_MonDo = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_MonDo.Fill(ds_ChiTiet, "MonDo");

            dt = ds_ChiTiet.Tables["MonDo"];
            // txtMahoadon.Text = im.Import_ID.ToString();
            DropDownList2.SelectedValue = dt.Rows[0][1].ToString();
            DropDownList3.SelectedValue = dt.Rows[0][2].ToString();
            txtSL.Text = dt.Rows[0][3].ToString();
            txtThanhtien.Text = dt.Rows[0][4].ToString();
            GridView1.EditIndex = e.NewEditIndex;
            load();

            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Label lblMa = (Label)GridView1.Rows[e.RowIndex].FindControl("lbMaSP");
            //tbl_ImportDetail im = db.tbl_ImportDetails.SingleOrDefault(c => c.Product_ID == int.Parse(lblMa.Text));
            //db.tbl_ImportDetails.DeleteOnSubmit(im);
            //db.SubmitChanges();
            //load();
        }
    }
}