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
    public partial class ThanhToan : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_Payment = new DataSet();
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
            }
        }

        protected void btnTiepTuc1_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                txtHoTen1.Text = Session["hoten"].ToString();
                if (Session["SDT"] != null)
                {
                    txtSDT1.Text = Session["SDT"].ToString();
                }
                string diachi = (string)Session["diachi"];
                string[] dc = new string[4];
                int i = 0;
                foreach (string con in diachi.Split('-'))
                {
                    dc[i] = con;
                    i++;
                }
                txtDiaChi1.Text = dc[0];
                txtQuanHuyen1.Text = dc[1];
                txtTinh1.Text = dc[2];
                txtQuocGia1.Text = dc[3];

            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                txtHoTen2.Text = txtHoTen1.Text;
                txtDiaChi2.Text = txtDiaChi1.Text;
                txtQuanHuyen2.Text = txtQuanHuyen1.Text;
                txtTinh2.Text = txtTinh1.Text;
                txtQuocGia2.Text = txtQuocGia1.Text;
                txtSDT2.Text = txtSDT1.Text;
                //Download source code FREE tai Sharecode.vn
            }
        }

        protected void btnTiepTuc2_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            Panel4.Visible = false;
            double phivanchuyen = 0;
            double tongtien = 0;
            double trongluong = 0;
            double goihang = 0;
            double tongtatca = 0;
            GioHang gh = (GioHang)Session["giohang"];
            DataTable tb = gh.GetDataTable();

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                tongtien = tongtien + Convert.ToDouble(tb.Rows[i][8].ToString());
                trongluong = trongluong + (Convert.ToDouble(tb.Rows[i][6].ToString()) * Convert.ToDouble(tb.Rows[i][1].ToString()));
            }
            string HTTT = "";
            string[] GH;
            string[] TT;
            string HTVC = "";
            Panel3.Visible = true;
            TT = new string[3];
            TT[0] = txtHoTen1.Text;
            TT[1] = txtDiaChi1.Text + "-" + txtQuanHuyen1.Text + "-" + txtTinh1.Text + "-" + txtQuocGia1.Text;
            TT[2] = txtSDT2.Text;
            Session["HotenTT"] = TT[0];
            Session["DiachiTT"] = TT[1];
            Session["SodtTT"] = TT[2];
            GH = new string[3];
            GH[0] = txtHoTen2.Text;
            GH[1] = txtDiaChi2.Text + "-" + txtQuanHuyen2.Text + "-" + txtTinh2.Text + "-" + txtQuocGia2.Text;
            GH[2] = txtSDT2.Text;
            Session["HotenGH"] = GH[0];
            Session["DiachiGH"] = GH[1];
            Session["SodtGH"] = GH[2];
            if (RadioButtonList1.Items.Count > 0)
            {
                HTTT = RadioButtonList2.SelectedItem.Value.ToString();
            }
            if (RadioButtonList1.Items.Count > 0)
            {
                HTVC = RadioButtonList1.SelectedItem.Value.ToString();
                if (RadioButtonList1.SelectedItem.Value == "Chuyển phát nhanh")
                {
                    phivanchuyen = 108 * trongluong;
                }
                if (RadioButtonList1.SelectedItem.Value == "Chuyển qua bưu điện")
                {
                    phivanchuyen = 40 * trongluong;
                }
                if (RadioButtonList1.SelectedItem.Value == "Chuyển bằng ô tô")
                {
                    phivanchuyen = 25000;
                }
                if (RadioButtonList1.SelectedItem.Value == "Giao hàng trực tiếp")
                {
                    phivanchuyen = 0;
                }
                Session["pvc"] = phivanchuyen;
            }
            Session["HTTT"] = HTTT;
            Session["HTVC"] = HTVC;
            Panel2.Visible = false;
            Panel1.Visible = false;
            GridView1.DataSource = tb;
            GridView1.DataBind();
            lblPhiVanChuyen.Text = phivanchuyen.ToString("###,###").Replace(',', '.') + "Đ";
            if (CheckGoiQua.Checked == true)
            {
                goihang = 20000;
                lblgoiqua.Text = "Có";
                lblLoiNhan.Text = txtGoiQua.Text;
            }
            else
                lblgoiqua.Text = "Không";
            lbltienmuahang.Text = tongtien.ToString("###,###").Replace(',', '.');
            Session["ttl"] = trongluong;
            lbltongtrongluong.Text = trongluong.ToString();
            Session["pgh"] = goihang;
            lblPhiGoiHang.Text = goihang.ToString("###,###").Replace(',', '.');
            tongtatca = phivanchuyen + tongtien + goihang;
            Session["ttc"] = tongtatca;
            lblTongTien.Text = tongtatca.ToString("###,###").Replace(',', '.');
            lblHoTen.Text = (string)Session["HotenTT"];
            lblDiaChi.Text = (string)Session["DiachiTT"];
            lblSDT.Text = (string)Session["SodtTT"];
            lblHoTen0.Text = (string)Session["HotenGH"];
            lblDiaChi0.Text = (string)Session["DiachiGH"];
            lblSDT0.Text = (string)Session["SodtGH"];
            lblHTTT.Text = (string)Session["HTTT"];
            lblHTVC.Text = (string)Session["HTVC"];
            //Download source code FREE tai Sharecode.vn
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            GioHang gh = (GioHang)Session["giohang"];
            DataTable tb = gh.GetDataTable();
            DataTable dtOrder;
            DataTable dtTransport;
            DataTable dtPayment;
            //Lấy mã max làm mã auto
            cmmSELECT = "SELECT Order_ID FROM tbl_Order";
            SqlDataAdapter da_Order = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_Order.Fill(ds_Payment, "Order");
            dtOrder = ds_Payment.Tables["Order"];

            //set mã auto
            double mamax = macuoi(dtOrder);
            string ma = (mamax + 1).ToString();
            DateTime ngay = System.DateTime.Now;

            //Lấy giá trị hình thức vận chuyển
            string cmmTransport = "SELECT Transport_ID, Transport_Name FROM tbl_Transport WHERE Transport_Name = N'"+(string) Session["HTVC"] + "'";
            SqlDataAdapter da_Transport = new SqlDataAdapter(cmmTransport,conn.Conn);
            da_Transport.Fill(ds_Payment, "Transport");
            dtTransport = ds_Payment.Tables["Transport"];

            //Lấy giá trị hình thức thanh toán
            string cmmPayment = "SELECT Pay_ID, Pay_Name FROM tbl_Payment WHERE Pay_Name= N'"+ (string) Session["HTTT"]+"'";
            SqlDataAdapter da_Payment = new SqlDataAdapter(cmmPayment, conn.Conn);
            da_Payment.Fill(ds_Payment, "Payment");
            dtPayment = ds_Payment.Tables["Payment"];

            //Gán giá trị tạo hóa đơn
            string OrderID = ma;
            string User = (string)Session["UserName"];
            DateTime date = Convert.ToDateTime(ngay);
            string PayID = dtPayment.Rows[0][0].ToString();
            string TransportID = dtTransport.Rows[0][0].ToString();
            string Name_Received = (string)Session["HotenGH"];
            string Address_Received = (string)Session["DiachiGH"];
            int Phone_Received = Convert.ToInt32(Session["SodtGH"]);
            string Name_Pay = (string)Session["HotenTT"];
            string Address_Pay = (string)Session["DiachiTT"];
            int Phone_Pay = Convert.ToInt32(Session["SodtTT"]);
            double VAT_Gift = Convert.ToDouble(Session["pgh"]);
            string Mesage = lblLoiNhan.Text;
            double SumWeight = Convert.ToDouble(Session["ttl"]);
            double VAT_Transport = Convert.ToDouble(Session["pvc"]);
            double SumMoney = Convert.ToDouble(Session["ttc"]);

            //INSERT vào Database Order
            string cmmINSERT = "INSERT INTO tbl_Order VALUES('"+OrderID+"','"+User+"','"+date+"','"+PayID+"','"+TransportID+"','"+Name_Received+"','"+Address_Received+"','"+Phone_Received+"','"+Name_Pay+"','"+Address_Pay+"','"+Phone_Pay+"','"+Mesage+"','"+VAT_Gift+"','"+SumWeight+"','"+VAT_Transport+"','"+SumMoney+"','Đang giao')";
            SqlCommand cmm = new SqlCommand(cmmINSERT,conn.Conn);
            cmm.ExecuteNonQuery();

            //INSERT vào Database OrderDetial
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                
                string Order_ID = ma;
                int Product_ID = Convert.ToInt32(tb.Rows[i][7].ToString());
                double Price_Export = Convert.ToDouble(tb.Rows[i][2].ToString());
                int Amount = Convert.ToInt32(tb.Rows[i][1].ToString());
                double Money = Convert.ToDouble(tb.Rows[i][8].ToString());
                string cmmINSERTDetial = "INSERT INTO tbl_OrderDetial VALUES('"+Order_ID+"','"+Product_ID+"','"+Price_Export+"','"+Amount+"','"+Money+"')";
                SqlCommand cmmINSERTD = new SqlCommand(cmmINSERTDetial,conn.Conn);
                cmmINSERTD.ExecuteNonQuery();
            }

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = true;
            Session["GioHang"] = null;
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        public double macuoi(DataTable dt)
        {
            double max = 0;
            foreach (DataRow dr in dt.Rows)
            {
                double pt = double.Parse(dr[0].ToString());
                if (pt > max) max = pt;
            }
            return max;
        }

        protected void LinkThayDoiDCTT_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }

        protected void LinkThayDoiDCGH_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }

        protected void LinkThayDoiHTVC_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }

        protected void LinkThayDoiHTTT_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }

        protected void btnQuayLai2_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel1.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }
    }
}