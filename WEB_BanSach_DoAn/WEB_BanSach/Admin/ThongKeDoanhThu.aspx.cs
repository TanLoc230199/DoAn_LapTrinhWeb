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
    public partial class ThongKeDoanhThu : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_HoaDon = new DataSet();
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
        void tinhtoan()
        {
            double tongtiennhap = 0;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                tongtiennhap += double.Parse(gr.Cells[5].Text);
            }
            Label1.Text = tongtiennhap.ToString("###,###") + "  " + "VNĐ";
        }
        protected void btnThongke_Click(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            if (RadioButtonList1.Items[0].Selected)
            {
                txtTungay.Text = "";
                txtDenngay.Text = "";
                txtNam.Text = "";
                if (txtNgay.Text != "")
                {
                    cmmSELECT = "select o.Date as[Ngày bán], od.Product_ID as[Mã sản phẩm],p.Price_Import as[Giá nhập], p.Price_Export as[Giá xuất],sum(od.Amount) as[Số lượng], ((p.Price_Export - p.Price_Import) * sum(od.Amount)) as[Thành tiền] from tbl_Order o,tbl_OrderDetial od, tbl_Product p where o.Order_ID = od.Order_ID and od.Product_ID = p.Product_ID and convert(datetime, substring(convert (nvarchar(50),o.date),0,len(o.date) - 6)) = '" + Convert.ToDateTime(txtNgay.Text) + "' group by od.Product_ID,p.Price_Import,p.Price_Export,o.Date";
                    SqlDataAdapter da_TheoNgay = new SqlDataAdapter(cmmSELECT, conn.Conn);
                    da_TheoNgay.Fill(ds_HoaDon, "TheoNgay");

                    GridView1.DataSource = ds_HoaDon.Tables["TheoNgay"];
                    GridView1.DataBind();
                    Label2.Text = "Doanh thu:";
                    tinhtoan();
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
                txtNam.Text = "";
                if (txtTungay.Text != "" && txtDenngay.Text != "")
                {
                    cmmSELECT = "select o.Date as[Ngày bán], od.Product_ID as[Mã sản phẩm],p.Price_Import as[Giá nhập], p.Price_Export as[Giá xuất],sum(od.Amount) as[Số lượng], ((p.Price_Export - p.Price_Import) * sum(od.Amount)) as[Thành tiền] from tbl_Order o,tbl_OrderDetial od, tbl_Product p where o.Order_ID = od.Order_ID and od.Product_ID = p.Product_ID and convert(datetime, substring(convert (nvarchar(50),o.date),0,len(o.date) - 6)) >= '" + Convert.ToDateTime(txtTungay.Text) + "' and convert(datetime, substring(convert (nvarchar(50),o.date),0,len(o.date) - 6)) <= '" + Convert.ToDateTime(txtDenngay.Text) + "' group by od.Product_ID,p.Price_Import,p.Price_Export,o.Date ";
                    SqlDataAdapter da_TheoThoiGian = new SqlDataAdapter(cmmSELECT, conn.Conn);
                    da_TheoThoiGian.Fill(ds_HoaDon, "TheoThoiGian");

                    GridView1.DataSource = ds_HoaDon.Tables["TheoThoiGian"];
                    GridView1.DataBind();
                    Label2.Text = "Doanh thu:";
                    tinhtoan();
                }
                else
                {
                    lblThongBao.Text = "Từ ngày + đến ngày thống kê không được bỏ trống";
                    txtTungay.Focus();
                }
            }
            if (RadioButtonList1.Items[2].Selected)
            {
                txtNgay.Text = "";
                txtTungay.Text = "";
                txtDenngay.Text = "";
                if (txtNam.Text != "")
                {
                    cmmSELECT = "select i.Date as[Ngày nhập],im.Import_ID as[Mã hoá đơn],i.Supplier_ID as[Nhà cung cấp],sum(im.Money) as [Thành tiền] from tbl_Import i,tbl_ImportDetail im where i.Import_ID = im.Import_ID and Year(i.Date) = '" + int.Parse(txtNam.Text) + "' group by  i.Date,im.Import_ID,i.Supplier_ID";
                    SqlDataAdapter da_TheoNam = new SqlDataAdapter(cmmSELECT, conn.Conn);
                    da_TheoNam.Fill(ds_HoaDon, "TheoNam");

                    GridView1.DataSource = ds_HoaDon.Tables["TheoNam"];
                    GridView1.DataBind();
                    Label2.Text = "Doanh thu:";
                    double tongtiennhap = 0;
                    foreach (GridViewRow gr in GridView1.Rows)
                    {
                        tongtiennhap += double.Parse(gr.Cells[3].Text);
                    }
                    Label1.Text = tongtiennhap.ToString("###,###") + "  " + "VNĐ";
                }
                else
                {
                    lblThongBao.Text = "Năm thống kê không được bỏ trống";
                    txtNam.Focus();
                }
            }
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
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
    }
}