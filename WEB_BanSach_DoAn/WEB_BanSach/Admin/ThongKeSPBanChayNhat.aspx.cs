using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_BanSach
{
    public partial class ThongKeSPBanChayNhat : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_SanPham = new DataSet();
        DataTable dt;
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnThongke_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.Items[0].Selected)
            {
                txtTungay.Text = "";
                txtDenngay.Text = "";
                txtTheonam.Text = "";
                if (txtTheongay.Text != "")
                {
                    cmmSELECT = "select od.Product_ID as [Mã sản phẩm],od.Price_Export as [Giá bán],sum(od.Amount) as [Số lượng],sum(od.Money) as[Tổng tiền] from tbl_Order o,tbl_OrderDetial od where o.Order_ID = od.Order_ID and convert(datetime, substring(convert (nvarchar(50),o.date),0,len(o.date) - 6))= convert(datetime, '"+Convert.ToDateTime(txtTheongay.Text)+"') group by od.Product_ID,od.Price_Export,od.Amount";
                    SqlDataAdapter da_TheoNgay = new SqlDataAdapter(cmmSELECT, conn.Conn);
                    da_TheoNgay.Fill(ds_SanPham, "TheoNgay");

                    GridView1.DataSource = ds_SanPham.Tables["TheoNgay"];
                    GridView1.DataBind();
                }
                else
                {
                    lblThongBao.Text = "Ngày thống kê không được bỏ trống";
                    txtTheongay.Focus();
                }
                if (GridView1.Rows.Count > 0)
                { }
                else
                {
                    Response.Write("<script language='javascript'>alert('" + "Không có sản phẩm nào" + "')</script>");

                }
                //Response.Redirect("ThongkeSPbanchaynhat.aspx");
            }
            if (RadioButtonList1.Items[1].Selected)
            {
                txtTheongay.Text = "";
                txtTheonam.Text = "";
                if (txtTheongay.Text != "" && txtDenngay.Text != "")
                {
                    cmmSELECT = "select o.Date as[Ngày],od.Product_ID as[Mã sản phẩm],od.Price_Export as[Giá xuất],od.Amount as[Số lượng],od.Money as[Thành tiền] from tbl_Order o, tbl_OrderDetial od where o.Order_ID = od.Order_ID and convert(datetime, substring(convert (nvarchar(50),o.date),0,len(o.date) - 6)) >= convert(datetime, '"+Convert.ToDateTime(txtTungay.Text) +"') and convert(datetime, substring(convert (nvarchar(50),o.date),0,len(o.date) - 6)) <= convert(datetime, '"+Convert.ToDateTime(txtDenngay.Text)+"') order by od.Amount desc";
                    SqlDataAdapter da_TheoThoiGian = new SqlDataAdapter(cmmSELECT, conn.Conn);
                    da_TheoThoiGian.Fill(ds_SanPham, "TheoThoiGian");

                    GridView1.DataSource = ds_SanPham.Tables["TheoThoiGian"];
                    GridView1.DataBind();
                }
                else
                {
                    lblThongBao.Text = "Từ ngày + Đến ngày thống kê không được bỏ trống";
                    txtTheongay.Focus();
                }
                if (GridView1.Rows.Count > 0)
                { }
                else
                {
                    Response.Write("<script language='javascript'>alert('" + "Không có sản phẩm nào" + "')</script>");
                    //Response.Redirect("ThongkeSPbanchaynhat.aspx");
                }
            }
            if (RadioButtonList1.Items[2].Selected)
            {
                txtTungay.Text = "";
                txtDenngay.Text = "";
                txtTheongay.Text = "";
                if (txtTheonam.Text != "")
                {
                    cmmSELECT = "select od.Product_ID as[Mã sản phẩm],od.Price_Export as[Giá xuất],sum(od.Amount) as[Số lượng],sum(od.Money) as[Thành tiền] from tbl_Order o, tbl_OrderDetial od where o.Order_ID = od.Order_ID and Year(o.Date) = '"+ int.Parse(txtTheonam.Text)+"' group by od.Product_ID,od.Price_Export order by od.Product_ID,od.Price_Export";
                    SqlDataAdapter da_TheoNam = new SqlDataAdapter(cmmSELECT, conn.Conn);
                    da_TheoNam.Fill(ds_SanPham, "TheoNam");

                    GridView1.DataSource = ds_SanPham.Tables["TheoNam"];
                    GridView1.DataBind();
                }
                else
                {
                    lblThongBao.Text = "Năm thống kê không được bỏ trống";
                    txtTheonam.Focus();
                }
                if (GridView1.Rows.Count > 0)
                { }
                else
                {
                    Response.Write("<script language='javascript'>alert('" + "Không có sản phẩm nào" + "')</script>");
                    //Response.Redirect("ThongkeSPbanchaynhat.aspx");
                }
            }
        }

        protected void txtDenngay_CalendarExtender_SelectionChanged(object sender, EventArgs e)
        {
            txtDenngay.Text = txtDenngay_CalendarExtender.SelectedDate.ToString();
        }

        protected void txtTungay_CalendarExtender_SelectionChanged(object sender, EventArgs e)
        {
            txtTungay.Text = txtTungay_CalendarExtender.SelectedDate.ToString();
        }

        protected void txtTheongay_CalendarExtender_SelectionChanged(object sender, EventArgs e)
        {
            txtTheongay.Text = txtTheongay_CalendarExtender.SelectedDate.ToString();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

        }
    }
}