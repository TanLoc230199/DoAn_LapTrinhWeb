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
    public partial class ThongKeNhapHang : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_DonNhap = new DataSet();
        DataTable dt;
        string cmmSELECT = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["Username"] != null) 
            { 
                Label2.Text = ""; 
            }
            else
                Response.Redirect("Login.aspx");
        }
        void tinh()
        {
            double tongtiennhap = 0;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                tongtiennhap += double.Parse(gr.Cells[3].Text);
            }
            Label1.Text = tongtiennhap.ToString("###,###") + "  " + "VNĐ";
        }
        protected void btnThongke_Click(object sender, EventArgs e)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            if (RadioButtonList1.Items[0].Selected)
            {
                txtTungay.Text = "";
                txtDenngay.Text = "";
                txtTheonam.Text = "";
                if (txtNgay.Text != "")
                { 
                    cmmSELECT = "select i.Date as[Ngày nhập],im.Import_ID as[Mã hoá đơn],i.Supplier_ID as[Nhà cung cấp],sum(im.Money) as [Thành tiền] from tbl_Import i,tbl_ImportDetail im where i.Import_ID = im.Import_ID and convert(datetime, substring(convert (nvarchar(50),i.Date),0,len(i.Date) - 6)) = '" + Convert.ToDateTime(txtNgay.Text) + "' group by  i.Date,im.Import_ID,i.Supplier_ID";
                    SqlDataAdapter da_TheoNgay = new SqlDataAdapter(cmmSELECT, conn.Conn);
                    da_TheoNgay.Fill(ds_DonNhap, "TheoNgay");
                    GridView1.DataSource = ds_DonNhap.Tables["TheoNgay"];
                    GridView1.DataBind();
                    Label2.Text = "Tổng tiền nhập: ";
                    tinh();
                }
                else
                {
                    lblThongBao.Text = "Ngày thống kê không được bỏ trống";
                    txtNgay.Focus();
                }

            }
            if (RadioButtonList1.Items[1].Selected)
            {
                txtNgay.Text = "";
                txtTheonam.Text = "";
                if (txtDenngay.Text != "" && txtTungay.Text != "")
                {
                    cmmSELECT = "select i.Date as[Ngày nhập],im.Import_ID as[Mã sản phẩm],i.Supplier_ID as[Nhà cung cấp],sum(im.Money) as [Thành tiền] from tbl_Import i,tbl_ImportDetail im where i.Import_ID = im.Import_ID and convert(datetime, substring(convert (nvarchar(50),i.Date),0,len(i.Date) - 6)) >= '" + Convert.ToDateTime(txtTungay.Text) + "' and convert(datetime, substring(convert (nvarchar(50),i.Date),0,len(i.Date) - 6))<= '" + Convert.ToDateTime(txtDenngay.Text) + "' group by  i.Date,im.Import_ID,i.Supplier_ID";
                    SqlDataAdapter da_TheoThoiGian = new SqlDataAdapter(cmmSELECT, conn.Conn);
                    da_TheoThoiGian.Fill(ds_DonNhap, "TheoThoiGian");
                    GridView1.DataSource = ds_DonNhap.Tables["TheoThoiGian"];
                    GridView1.DataBind();
                    Label2.Text = "Tổng tiền nhập: ";
                    tinh();
                }
                else
                {
                    lblThongBao.Text = "Từ Ngày + Đến Ngày thống kê không được bỏ trống";
                    txtTungay.Focus();
                }
            }
            if (RadioButtonList1.Items[2].Selected)
            {
                txtNgay.Text = "";
                txtTungay.Text = "";
                txtDenngay.Text = "";
                if (txtTheonam.Text != "")
                {
                    cmmSELECT = "select od.Product_ID as[Mã sản phẩm],od.Price_Export as[Giá xuất],sum(od.Amount) as[Số lượng],sum(od.Money) as[Thành tiền] from tbl_Order o, tbl_OrderDetial od where o.Order_ID = od.Order_ID and Year(o.Date) = '" + int.Parse(txtTheonam.Text) + "' group by od.Product_ID,od.Price_Export order by od.Product_ID,od.Price_Export";
                    SqlDataAdapter da_TheoNam = new SqlDataAdapter(cmmSELECT, conn.Conn);
                    da_TheoNam.Fill(ds_DonNhap, "TheoNam");

                    GridView1.DataSource = ds_DonNhap.Tables["TheoNam"];
                    GridView1.DataBind();
                    Label2.Text = "Tổng tiền nhập: ";
                    tinh();
                }
                else
                {
                    lblThongBao.Text = "Năm thống kê không được bỏ trống";
                    txtTheonam.Focus();
                }
            }
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void txtNgay_CalendarExtender_SelectionChanged(object sender, EventArgs e)
        {
            txtNgay.Text = txtNgay_CalendarExtender.SelectedDate.ToString();
        }

        protected void txtTungay_CalendarExtender_SelectionChanged(object sender, EventArgs e)
        {
            txtTungay.Text = txtTungay_CalendarExtender.SelectedDate.ToString();
        }

        protected void txtDenngay_CalendarExtender_SelectionChanged(object sender, EventArgs e)
        {
            txtDenngay.Text = txtDenngay_CalendarExtender.SelectedDate.ToString();
        }

        //protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    foreach (ListItem r in RadioButtonList1.Items)
        //    {
        //        if (RadioButtonList1.Items[0].Selected)
        //        {
        //            lblNgay.Visible = true;
        //            lblTuNgay.Visible = false;
        //            lblDenNgay.Visible = false;
        //            lblNam.Visible = false;

        //            txtNgay.Visible = true;
        //            txtTungay.Visible = false;
        //            txtDenngay.Visible = false;
        //            txtTheonam.Visible = false;

        //            txtNgay_CalendarExtender.Visible = true;
        //            txtTungay_CalendarExtender.Visible = false;
        //            txtDenngay_CalendarExtender.Visible = false;

        //        }
        //        else if (RadioButtonList1.Items[1].Selected)
        //        {
        //            lblNgay.Visible = false;
        //            lblTuNgay.Visible = true;
        //            lblDenNgay.Visible = true;
        //            lblNam.Visible = false;

        //            txtNgay.Visible = false;
        //            txtTungay.Visible = true;
        //            txtDenngay.Visible = true;
        //            txtTheonam.Visible = false;

        //            txtNgay_CalendarExtender.Visible = false;
        //            txtTungay_CalendarExtender.Visible = true;
        //            txtDenngay_CalendarExtender.Visible = true;
        //        }
        //        else if (RadioButtonList1.Items[2].Selected)
        //        {
        //            lblNgay.Visible = false;
        //            lblTuNgay.Visible = false;
        //            lblDenNgay.Visible = false;
        //            lblNam.Visible = true;

        //            txtNgay.Visible = false;
        //            txtTungay.Visible = false;
        //            txtDenngay.Visible = false;
        //            txtTheonam.Visible = true;

        //            txtNgay_CalendarExtender.Visible = false;
        //            txtTungay_CalendarExtender.Visible = false;
        //            txtDenngay_CalendarExtender.Visible = false;
        //        }
        //    }
        //}
    }
}