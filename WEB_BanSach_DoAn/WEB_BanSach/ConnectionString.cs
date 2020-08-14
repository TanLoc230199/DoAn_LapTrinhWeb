using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_BanSach
{
    public class ConnectionString
    {
        private string strConn;
        private System.Data.SqlClient.SqlConnection conn;

        public string StrConn
        {
            get { return strConn; }
        }

        public System.Data.SqlClient.SqlConnection Conn
        {
            get { return conn; }
        }

        public ConnectionString()
        {
            strConn = "Data Source=LAPTOP-UCLG3AIH\\SQLEXPRESS;Initial Catalog=QuanLyBanSach;Integrated Security=True";
            conn = new System.Data.SqlClient.SqlConnection(strConn);
        }
        public ConnectionString(string DB)
        {
            strConn = "Data Source=LAPTOP-UCLG3AIH\\SQLEXPRESS;Initial Catalog='" + DB + "';Integrated Security=True";
            conn = new System.Data.SqlClient.SqlConnection(strConn);
        }
    }
}