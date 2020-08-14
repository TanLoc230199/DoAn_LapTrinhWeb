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
    public partial class ThongTinTaiKhoan : System.Web.UI.Page
    {
        ConnectionString conn = new ConnectionString();
        DataSet ds_TaiKhoan = new DataSet();
        DataTable dt;
        string cmmSELECT = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            string user = Convert.ToString(Session["UserName"]);
            cmmSELECT = "SELECT * FROM tbl_Customer WHERE [User]= '" + user + "'";
            SqlDataAdapter da_TaiKhoan = new SqlDataAdapter(cmmSELECT, conn.Conn);
            da_TaiKhoan.Fill(ds_TaiKhoan, "TaiKhoan");
            dt = ds_TaiKhoan.Tables["TaiKhoan"];

            lblTenDN.Text = dt.Rows[0][0].ToString();
            lblMatKhau.Text = "******";
            if (dt.Rows[0][2].ToString() != "")
                lblTen.Text = dt.Rows[0][2].ToString();
            else
                lblTen.Text = "(Chưa có thông tin)";
            if (dt.Rows[0][4].ToString() != "")
                lblDiaChi.Text = dt.Rows[0][4].ToString();
            else
                lblDiaChi.Text = "(Chưa có thông tin)";
            if (dt.Rows[0][3].ToString() != "")
                lblEmail.Text = dt.Rows[0][3].ToString();
            else
                lblEmail.Text = "(Chưa có thông tin)";
            if (dt.Rows[0][5].ToString() != null)
                lblSDT.Text = dt.Rows[0][5].ToString().ToString();
            else
                lblSDT.Text = "(Chưa có thông tin)";
            Panel2.Visible = false;
            Panel3.Visible = false;
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            Label1.Text = "";
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel1.Visible = false;
            txtTendaydu.Text = Session["hoten"].ToString();
            if (Session["SDT"] != null)
            {
                txtSDT.Text = Session["SDT"].ToString();
            }
            string diachi = (string)Session["diachi"];
            string[] dc = new string[4];
            int i = 0;
            foreach (string con in diachi.Split('-'))
            {
                dc[i] = con;
                i++;
            }
            txtDiachi.Text = dc[0];
            txtQuanHuyen.Text = dc[1];
            txtTinhThanh.Text = dc[2];
            txtQuocGia.Text = dc[3];
        }
        public bool Check_TonTai(string _User)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            string user = Convert.ToString(Session["UserName"]);
            cmmSELECT = "SELECT COUNT(*) FROM tbl_Customer WHERE [User]= '" + _User + "'";
            SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);

            int count = (int)cmm.ExecuteScalar();
            if (count > 0)
            {
                return true;
            }
            return false;
            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }
        protected void btnTiepTuc1_Click(object sender, ImageClickEventArgs e)
        {
            if (conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }

            if (Check_TonTai(Session["UserName"].ToString()))
            {
                string FullName = txtTendaydu.Text;
                string Email = txtEmail.Text;
                string Address = txtDiachi.Text;
                int Phone = int.Parse(txtSDT.Text);

                cmmSELECT = "UPDATE tbl_Customer SET FullName = N'" + FullName + "', Email = N'" + Email + "', Address = N'" + Address + "', Phone = '" + Phone + "' WHERE [User] = '"+Session["UserName"]+"'";
                SqlCommand cmm = new SqlCommand(cmmSELECT, conn.Conn);
                cmm.ExecuteNonQuery();
                Response.Write("<script language='javascript'>alert('" + "Cập nhật thành công!" + "')</script>");
            }

            if (conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if(conn.Conn.State == ConnectionState.Closed)
            {
                conn.Conn.Open();
            }
            Panel3.Visible = true;
            if (txtNewPass.Text == "" || RePass.Text == "")
            {
                Label1.Text = "Bạn chưa nhập đủ thông tin";
            }
            else
            {
                if (txtPass.Text != Convert.ToString(Session["pass"]))
                {
                    Label1.Text = Session["pass"].ToString();
                }
                else
                {
                    string user = Convert.ToString(Session["UserName"]);
                    if (Check_TonTai(user))
                    {
                        //Update database password
                        string password = txtNewPass.Text;
                        cmmSELECT = "UPDATE tbl_Customer SET Password = '" + password + "' WHERE [User] = '"+ user +"'";
                        SqlCommand cmm = new SqlCommand(cmmSELECT,conn.Conn);
                        cmm.ExecuteNonQuery();

                        //Hiện thông báo
                        Response.Write("<script language='javascript'>alert('" + "Đổi mật khẩu thành công" + "')</script>");
                        Panel1.Visible = true;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                    }
                }
            }
            if(conn.Conn.State == ConnectionState.Open)
            {
                conn.Conn.Close();
            }
        }


    }
}