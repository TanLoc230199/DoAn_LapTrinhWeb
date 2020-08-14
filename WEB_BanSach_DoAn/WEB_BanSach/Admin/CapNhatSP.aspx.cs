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
    public partial class CapNhatSP : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_SanPham = new DataSet();
        DataTable dt;
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            load();
           
            if (Session["Username"] != null)
            {
                if (Session["Username"] != null)
                {
                    if (!KT_Admin())
                    {
                        Response.Write("<script language='javascript'>alert('" + "Bạn không có quyền vào trang này" + "')</script>");
                        Response.Redirect("NhapHang.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        public bool KT_Admin()
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT Power FROM tbl_Account WHERE Account = '" + Session["Username"].ToString() + "'";
            SqlDataAdapter da_Admin = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_Admin.Fill(ds_SanPham, "Admin");
            dt = ds_SanPham.Tables["Admin"];

            if (dt.Rows[0][0].ToString() == "Nhân viên")
            {
                return false;
            }
            return true;
            if (conn.Conn.State == ConnectionState.Open)
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

            cmmSELECT = "SELECT Product_ID, Product_Name, Type_ID, Style_ID, Supplier_ID, Producer_ID, Image, Price_Import, Price_Export  FROM tbl_Product";
            SqlDataAdapter da_SanPham = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_SanPham.Fill(ds_SanPham, "SanPham");

            GridView1.DataSource = ds_SanPham.Tables["SanPham"];
            GridView1.DataBind();
            if(ds_SanPham.Tables["SanPham"].Rows.Count >0)
            {
                ds_SanPham.Tables["SanPham"].Clear();
            }
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

       
        void rong()
        {
            txtMa.Text = "";
            txtTenSP.Text = "";
            txtMau.Text = "";
            txtKichthuoc.Text = "";
            txtChatlieu.Text = "";
            txtGianhap.Text = "";
            txtGiaxuat.Text = "";
            txtTrongluong.Text = "";
        }

        bool KTtontai(string ten, string loaisp, string pc, string ncc, string hsx, string mau, string kc, string cl, string gianhap, string gx, string trl)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT COUNT(*) FROM tbl_Product WHERE Product_Name = N'"+ ten + "' AND Type_ID = '"+ int.Parse(loaisp) + "' AND Style_ID = '"+ int.Parse(pc) + "' AND Supplier_ID = '"+ int.Parse(ncc) + "' AND Producer_ID = '"+ int.Parse(hsx) + "' AND Color = N'"+ mau + "' AND Material = N'"+ cl + "' AND Size = N'"+ kc + "' AND Price_Import = '"+ double.Parse(gianhap) + "' AND Price_Export = '"+ double.Parse(gx) + "' AND Weight = '"+ double.Parse(trl) + "'";
            SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);

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

        bool KTrong(string tensp, string gianhap, string giaxuat, string tl)
        {
            if (tensp == "" || gianhap == "" || giaxuat == "" || tl == "")
            {
                return false;
            }
            return true;
        }

        bool KTMaSP(string ma)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            cmmSELECT = "SELECT COUNT(*) FROM tbl_ImportDetail WHERE Product_ID = '"+ int.Parse(txtMa.Text) + "'";
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            load();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("CapNhatSP.aspx");
            txtTenSP.Focus();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            Label2.Text = "Bạn chọn lại hình ảnh";
            Label lbMa = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lbMa");

            cmmSELECT = "SELECT Product_ID, Product_Name, Type_ID, Style_ID, Supplier_ID, Producer_ID, Color, Material, Size, Price_Import, Price_Export, Weight FROM tbl_Product WHERE Product_ID = '" + int.Parse(lbMa.Text) +"'";
            SqlDataAdapter da_CTSanPham = new SqlDataAdapter(cmmSELECT,conn.Conn);
            da_CTSanPham.Fill(ds_SanPham, "CTSanPham");

            dt = ds_SanPham.Tables["CTSanPham"];
            txtMa.Text = dt.Rows[0][0].ToString();
            txtTenSP.Text = dt.Rows[0][1].ToString();
            drLoaiSP.SelectedValue = dt.Rows[0][2].ToString(); 
            drPhongcach.SelectedValue = dt.Rows[0][3].ToString();
            drNhacungcap.SelectedValue = dt.Rows[0][4].ToString();
            drHangsanxuat.SelectedValue = dt.Rows[0][5].ToString();
            // FileUpload1.PostedFile = p.Image.ToString();
            txtMau.Text = dt.Rows[0][6].ToString();
            txtChatlieu.Text = dt.Rows[0][7].ToString();
            txtKichthuoc.Text = dt.Rows[0][8].ToString();
            txtGianhap.Text = dt.Rows[0][9].ToString();
            txtGiaxuat.Text = dt.Rows[0][10].ToString();
            txtTrongluong.Text = dt.Rows[0][11].ToString();
            GridView1.EditIndex = e.NewEditIndex;
            load();
            Label6.Text = "";
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
            if (KTrong(txtTenSP.Text, txtGianhap.Text, txtGiaxuat.Text, txtTrongluong.Text))
            {
                string anh = "";
                if (FileUpload1.HasFile)
                {
                    anh = FileUpload1.FileName.Replace(" ", "_");
                    FileUpload1.SaveAs(Server.MapPath("../AnhSanPham") + "\\" + anh);
                }

                cmmSELECT = "INSERT INTO tbl_Product VALUES(N'"+ txtTenSP.Text + "','"+ int.Parse(drLoaiSP.SelectedValue.ToString()) + "','"+ int.Parse(drPhongcach.SelectedValue.ToString()) + "','"+ int.Parse(drNhacungcap.SelectedValue.ToString()) + "','"+ int.Parse(drHangsanxuat.SelectedValue.ToString()) + "',N'"+ anh + "',N'"+ txtMau.Text + "',N'"+ txtChatlieu.Text + "',N'"+ txtKichthuoc.Text + "','"+ double.Parse(txtGianhap.Text) + "','"+ int.Parse(txtGiaxuat.Text) + "','0','"+ int.Parse(txtTrongluong.Text) + "')";
                SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
                cmm.ExecuteNonQuery();

                load();
                rong();
                Response.Write("<script language='javascript'>alert('" + "Thêm thành công." + "')</script>");
                txtTenSP.Focus();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('" + "Chưa nhập đủ thông tin." + "')</script>");
                Label6.Text = "";
            }
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
            if (txtMa.Text == "")
            {
                Label6.Text = "Bạn chưa chọn sản phẩm.";
                Label2.Text = "";
            }
            else
            {
                string anh = "";
                if (FileUpload1.HasFile)
                {
                    anh = FileUpload1.FileName.Replace(" ", "_");
                    FileUpload1.SaveAs(Server.MapPath("../AnhSanPham") + "\\" + anh);
                }

                cmmSELECT = "UPDATE tbl_Product SET Product_Name = N'"+ txtTenSP.Text.ToString() +"', Type_ID = '" + int.Parse(drLoaiSP.SelectedValue.ToString()) + "', Style_ID = '"+ int.Parse(drPhongcach.SelectedValue.ToString()) + "', Supplier_ID = '"+ int.Parse(drNhacungcap.SelectedValue.ToString()) + "', Producer_ID = '"+ int.Parse(drHangsanxuat.SelectedValue.ToString()) + "', Image = N'"+ anh +"', Color = N'"+ txtMau.Text.ToString() + "', Material= N'"+ txtChatlieu.Text.ToString() + "', Size = N'"+ txtKichthuoc.Text.ToString() + "', Price_Import = '"+ double.Parse(txtGianhap.Text) + "', Price_Export = '"+int.Parse(txtGiaxuat.Text.ToString()) + "', Weight= '"+ int.Parse(txtTrongluong.Text.ToString()) + "' WHERE Product_ID = '" + int.Parse(txtMa.Text) + "'";
                SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
                cmm.ExecuteNonQuery();
                load();
                Response.Write("<script language='javascript'>alert('" + "Sửa thành công." + "')</script>");
                Label6.Text = "";
                rong();
                txtTenSP.Focus();
                Label2.Text = "";
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
            if (txtMa.Text == "")
            {
                Label6.Text = "Bạn chưa chọn sản phẩm.";
            }
            else
            {
                if (KTMaSP(txtMa.Text))
                {
                    cmmSELECT = "DELETE FROM tbl_Product WHERE Product_ID = '"+ int.Parse(txtMa.Text) + "'";
                    SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
                    cmm.ExecuteNonQuery();
                    load();
                    Response.Write("<script language='javascript'>alert('" + "Xoá thành công." + "')</script>");
                    rong();
                    txtTenSP.Focus();
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('" + "Không thể xoá sản phẩm." + "')</script>");
                }
            }
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
    }
}