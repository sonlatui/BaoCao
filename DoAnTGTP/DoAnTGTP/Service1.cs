using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DoAnTGTP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
     [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
                      ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        static public string conn_taikhoan = @"Data Source=SON-VAIO\SQLEXPRESS;Initial Catalog=ws_taikhoan;Integrated Security=True";
        static public string conn_tacgia = @"Data Source=SON-VAIO\SQLEXPRESS;Initial Catalog=ws_tacgia;Integrated Security=True";
        static public string conn_tacpham = @"Data Source=SON-VAIO\SQLEXPRESS;Initial Catalog=ws_tacpham;Integrated Security=True";

        public User user = new User();

        public int Login(string username, string password)
        {
            try
            {
                SqlConnection conn = new SqlConnection(conn_taikhoan);
                conn.Open();
                string cmdStr = "select * from TaiKhoan";
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                string _username = "";
                string _password = "";
                while (dr.Read())
                {
                    _username = dr["Username"].ToString();
                    _password = dr["Password"].ToString();
                    if (_username.CompareTo(username) == 0 && _password.CompareTo(password) == 0)
                    {
                        user.Quyen = int.Parse(dr["Quyen"].ToString());
                        user.username = username;
                        return user.Quyen;
                    }

                }
                conn.Close();
                return user.Quyen = -1;


            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
        public User GetQuyen()
        {
            return user;
        }

        public void Logout()
        {
            user.Quyen = -1;
        }

        public string GetTSTGbyTG(string tacgia)
        {
            return GetTSTGbyTGsv(tacgia, user);
        }
        public string GetTSTGbyTGsv(string tacgia, User user)
        {
            if (user.Quyen == -1)
                return "Bạn không có quyền này, mời bạn đăng nhập!";
            else
                try
                {
                    SqlConnection conn = new SqlConnection(conn_tacgia);
                    conn.Open();
                    string cmdStr = "select * from TacGia where Ten LIKE N'%" + tacgia +"%'";
                    SqlCommand cmd = new SqlCommand(cmdStr, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    
                    string ketqua = "<table border=1 width=100%><tr><td width=20% align=center>Tên tác giả</td><td align=center>Tiểu sử</td></tr>";
                    if (dt.Rows.Count == 0)
                        return "Chưa có thông tin về tác giả này";
                    else
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ketqua += "<tr><td align=center>" + dt.Rows[i][1].ToString() + "</td>";
                            ketqua += "<td>" + dt.Rows[i][2].ToString() + "</td></tr>";
                        }
                    return ketqua += "</table>";
                }
                catch (Exception ex)
                {
                    throw new FaultException(ex.Message);
                }

        }
        public string GetTSTGbyND(string noidung)
        {
            return GetTSTGbyNDsv(noidung, user);
        }
        public string GetTSTGbyNDsv(string noidung, User user)
        {
            if (user.Quyen == -1)
                return "Bạn không có quyền này, mời bạn đăng nhập!";
            else
                try
                {
                    SqlConnection conn = new SqlConnection(conn_tacgia);
                    conn.Open();
                    string cmdStr = "select * from TacGia where NoiDung LIKE N'%" + noidung + "%'";
                    SqlCommand cmd = new SqlCommand(cmdStr, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();

                    string ketqua = "<table border=1 width=100%><tr><td width=20% align=center>Tên tác giả</td><td align=center>Tiểu sử</td></tr>";
                    if (dt.Rows.Count == 0)
                        return "Chưa có thông tin về tác giả này";
                    else
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ketqua += "<tr><td align=center>" + dt.Rows[i][1].ToString() + "</td>";
                            ketqua += "<td>" + dt.Rows[i][2].ToString() + "</td></tr>";
                        }
                    return ketqua += "</table>";
                }
                catch (Exception ex)
                {
                    throw new FaultException(ex.Message);
                }

        }

        public string GetTPbyTG(string tacgia)
        {
            return GetTPbyTGsv(tacgia, user);
        }
        public string GetTPbyTGsv(string tacgia, User user)
        {
            if (user.Quyen == -1)
                return "Bạn không có quyền này, mời bạn đăng nhập!";
            else
                try
                {
                    SqlConnection conn = new SqlConnection(conn_tacpham);
                    conn.Open();
                    string cmdStr = "select * from TacPham where TenTacGia LIKE N'%" + tacgia + "%'";
                    SqlCommand cmd = new SqlCommand(cmdStr, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    string ketqua = "<table border=1 style=text-align:center><tr><td>Tác Phẩm</td><td>Thể Loại</td><td>Nội Dung</td><td>Tác Giả</td></tr>";
                    if (dt.Rows.Count == 0)
                        return "Chưa có thông tin về tác giả này";
                    else
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ketqua += "<tr><td>" + dt.Rows[i][1].ToString() + "</td>";
                            ketqua += "<td>" + dt.Rows[i][2].ToString() + "</td>";
                            ketqua += "<td>" + dt.Rows[i][3].ToString() + "</td>";
                            ketqua += "<td>" + dt.Rows[i][4].ToString() + "</td></tr>";
                        }
                    return ketqua += "</table>";

                }
                catch (Exception ex)
                {
                    throw new FaultException(ex.Message);
                }

        } 
        public string GetTPbyTP(string tacpham)
        {
            return GetTPbyTPsv(tacpham, user);
        }
        public string GetTPbyTPsv(string tacpham, User user)
         {
             if (user.Quyen == -1)
                 return "Bạn không có quyền này, mời bạn đăng nhập!";
             else
                 try
                 {
                     SqlConnection conn = new SqlConnection(conn_tacpham);
                     conn.Open();
                     string cmdStr = "select * from TacPham where Ten LIKE N'%" + tacpham + "%'";
                     SqlCommand cmd = new SqlCommand(cmdStr, conn);
                     SqlDataAdapter da = new SqlDataAdapter(cmd);
                     DataTable dt = new DataTable();
                     da.Fill(dt);
                     conn.Close();
                     string ketqua = "<table border=1 style=text-align:center><tr><td>Tác Phẩm</td><td>Thể Loại</td><td>Nội Dung</td><td>Tác Giả</td></tr>";
                     if (dt.Rows.Count == 0)
                         return "Chưa có thông tin về tác giả này";
                     else
                         for (int i = 0; i < dt.Rows.Count; i++)
                         {
                             ketqua += "<tr><td>" + dt.Rows[i][1].ToString() + "</td>";
                             ketqua += "<td>" + dt.Rows[i][2].ToString() + "</td>";
                             ketqua += "<td>" + dt.Rows[i][3].ToString() + "</td>";
                             ketqua += "<td>" + dt.Rows[i][4].ToString() + "</td></tr>";
                         }
                     return ketqua += "</table>";


                 }
                 catch (Exception ex)
                 {
                     throw new FaultException(ex.Message);
                 }
         }
        public string GetTPbyTL(string theloai)
         {
             return GetTPbyTLsv(theloai, user);
         }
        public string GetTPbyTLsv(string theloai, User user)
         {
             if (user.Quyen == -1)
                 return "Bạn không có quyền này, mời bạn đăng nhập!";
             else
                 try
                 {
                     SqlConnection conn = new SqlConnection(conn_tacpham);
                     conn.Open();
                     string cmdStr = "select * from TacPham where TheLoai LIKE N'%" + theloai + "%'";
                     SqlCommand cmd = new SqlCommand(cmdStr, conn);
                     SqlDataAdapter da = new SqlDataAdapter(cmd);
                     DataTable dt = new DataTable();
                     da.Fill(dt);
                     conn.Close();
                     string ketqua = "<table border=1 style=text-align:center><tr><td>Tác Phẩm</td><td>Thể Loại</td><td>Nội Dung</td><td>Tác Giả</td></tr>";
                     if (dt.Rows.Count == 0)
                         return "Chưa có thông tin về tác giả này";
                     else
                         for (int i = 0; i < dt.Rows.Count; i++)
                         {
                             ketqua += "<tr><td>" + dt.Rows[i][1].ToString() + "</td>";
                             ketqua += "<td>" + dt.Rows[i][2].ToString() + "</td>";
                             ketqua += "<td>" + dt.Rows[i][3].ToString() + "</td>";
                             ketqua += "<td>" + dt.Rows[i][4].ToString() + "</td></tr>";
                         }
                     return ketqua += "</table>";


                 }
                 catch (Exception ex)
                 {
                     throw new FaultException(ex.Message);
                 }
         }
        public string GetTPbyND(string noidung)
         {
             return GetTPbyNDsv(noidung, user);
         }
        public string GetTPbyNDsv(string noidung, User user)
         {
             if (user.Quyen == -1)
                 return "Bạn không có quyền này, mời bạn đăng nhập!";
             else
                 try
                 {
                     SqlConnection conn = new SqlConnection(conn_tacpham);
                     conn.Open();
                     string cmdStr = "select * from TacPham where NoiDung LIKE N'%" + noidung + "%'";
                     SqlCommand cmd = new SqlCommand(cmdStr, conn);
                     SqlDataAdapter da = new SqlDataAdapter(cmd);
                     DataTable dt = new DataTable();
                     da.Fill(dt);
                     conn.Close();
                     string ketqua = "<table border=1 style=text-align:center><tr><td>Tác Phẩm</td><td>Thể Loại</td><td>Nội Dung</td><td>Tác Giả</td></tr>";
                     if (dt.Rows.Count == 0)
                         return "Chưa có thông tin về tác giả này";
                     else
                         for (int i = 0; i < dt.Rows.Count; i++)
                         {
                             ketqua += "<tr><td>" + dt.Rows[i][1].ToString() + "</td>";
                             ketqua += "<td>" + dt.Rows[i][2].ToString() + "</td>";
                             ketqua += "<td>" + dt.Rows[i][3].ToString() + "</td>";
                             ketqua += "<td>" + dt.Rows[i][4].ToString() + "</td></tr>";
                         }
                     return ketqua += "</table>";


                 }
                 catch (Exception ex)
                 {
                     throw new FaultException(ex.Message);
                 }
         }

        //public DataSet TimTSbyTen(string tacgia)
        //{
        //    return TimTSbyTensv(tacgia, user);
        //}
        //public DataSet TimTSbyTensv(string tacgia, User user)
        //{
        //    DataSet ds = new DataSet();
        //    if (user.Quyen == -1)
        //        return ds;
        //    else
        //        try
        //        {
        //            SqlConnection conn = new SqlConnection(conn_tacgia);
        //            conn.Open();
        //            string cmdStr = "select * from TacGia where Ten LIKE N'%" + tacgia + "%'";
        //            SqlCommand cmd = new SqlCommand(cmdStr, conn);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(ds, "TacGia");
        //            conn.Close();

        //            return ds;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new FaultException(ex.Message);
        //        }
 
        //}

        public string ThemTG(string tentg, string tieusu)
        {
            return ThemTGsv(tentg, tieusu, user);
 
        }
        public string ThemTGsv(string tentg, string tieusu, User user)
        {
            if (user.Quyen != 1)
                return "Bạn không có quyền này, mời bạn đăng nhập!";
            else
                try
                {
                    SqlConnection conn = new SqlConnection(conn_tacgia);
                    conn.Open();
                    string cmdStr = "Insert into TacGia (Ten,NoiDung) VALUES (N'" + tentg + "',N'"+ tieusu +"')";
                    SqlCommand cmd = new SqlCommand(cmdStr, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return "Thêm thành công";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
 
        }

        public string ThemTP(string tentp, string theloai, string noidung, string tentg)
        {
            return ThemTPsv(tentp, theloai, noidung, tentg, user);

        }
        public string ThemTPsv(string tentp, string theloai, string noidung, string tentg, User user)
        {
            if (user.Quyen != 1)
                return "Bạn không có quyền này, mời bạn đăng nhập!";
            else
                try
                {
                    SqlConnection conn = new SqlConnection(conn_tacpham);
                    conn.Open();
                    string cmdStr = "Insert into TacPham (Ten,TheLoai,NoiDung,TenTacGia) VALUES (N'" + tentp + "',N'" + theloai + "',N'" + noidung + "',N'" + tentg + "')";
                    SqlCommand cmd = new SqlCommand(cmdStr, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return "Thêm thành công";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

        }
    }
}
