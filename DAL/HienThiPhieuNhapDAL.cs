﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HienThiPhieuNhapDAL:AccessDataBase
    {
       // 
        public List<PhieuNhap> LayPhieuNhapTheoNgayThangNam(DateTime DateTime)
        {
            try
            {
                List<PhieuNhap> DanhSach = new List<PhieuNhap>();
                OpenDataBase();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "LayPhieuNhapTheoNgayThangNam";
                sqlCommand.Parameters.Add("@Nam", SqlDbType.DateTime).Value = DateTime;
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    DanhSach.Add(new PhieuNhap
                    {
                        MaPhieuNhap = sqlDataReader[0].ToString(),
                        NhanVien = sqlDataReader[1].ToString(),
                        NhaCungCap = sqlDataReader[2].ToString(),
                        NgayNhap = DateTime.Parse(sqlDataReader[3].ToString()),
                        KhoHang = sqlDataReader[4].ToString()
                    });
                }
                sqlDataReader.Close();
                return DanhSach;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PhieuNhap> LayThongTinPhieuNhapTheoMa(string maSanPham)
        {
            try
            {
                List<PhieuNhap> DanhSach = new List<PhieuNhap>();
                OpenDataBase();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "LayThongTinPhieuNhapTheoMa";
                sqlCommand.Parameters.Add("@MaPhieuNhap", SqlDbType.Char).Value = maSanPham;
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    DanhSach.Add(new PhieuNhap
                    {
                        MaPhieuNhap = sqlDataReader[0].ToString(),
                        NhanVien = sqlDataReader[1].ToString(),
                        NhaCungCap = sqlDataReader[2].ToString(),
                        NgayNhap = DateTime.Parse(sqlDataReader[3].ToString()),
                        KhoHang = sqlDataReader[4].ToString()
                    });
                }
                sqlDataReader.Close();
                return DanhSach;
            }
            catch 
            {
                return null;
            }
        }

        //
        public bool ThemMoiPhieuNhap(PhieuNhap phieuNhap)
        {
            try
            {
                List<PhieuNhap> DanhSach = new List<PhieuNhap>();
                OpenDataBase();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "ThemMoiPhieuNhap";
                sqlCommand.Parameters.Add("@MaPhieuNhap", SqlDbType.Char).Value = phieuNhap.MaPhieuNhap;
                sqlCommand.Parameters.Add("@MaNhanVien", SqlDbType.Char).Value = phieuNhap.NhanVien;
                sqlCommand.Parameters.Add("@MaNhaCungCap", SqlDbType.Char).Value = phieuNhap.NhaCungCap;
                sqlCommand.Parameters.Add("@NgayNhap", SqlDbType.DateTime).Value = phieuNhap.NgayNhap;
                sqlCommand.Connection = sqlConnection;
                int k = sqlCommand.ExecuteNonQuery();
                return k > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    



        //
        public bool SuaThongTinPhieuNhap(PhieuNhap phieuNhap)
        {
            try
            {
                List<PhieuNhap> DanhSach = new List<PhieuNhap>();
                OpenDataBase();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "CapNhapThongTinPhieuNhaps";
                sqlCommand.Parameters.Add("@MaPhieuNhap", SqlDbType.Char).Value = phieuNhap.MaPhieuNhap;
                sqlCommand.Parameters.Add("@MaNhanVien", SqlDbType.Char).Value = phieuNhap.NhanVien;
                sqlCommand.Parameters.Add("@MaNhaCungCap", SqlDbType.Char).Value = phieuNhap.NhaCungCap;
                sqlCommand.Parameters.Add("@NgayNhap", SqlDbType.DateTime).Value = phieuNhap.NgayNhap;
                sqlCommand.Connection = sqlConnection;
                int k = sqlCommand.ExecuteNonQuery();
                return k > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool XoaThongTinPhieuNhap(string MaPhieuNhap)
        {
            try
            {
                List<PhieuNhap> DanhSach = new List<PhieuNhap>();
                OpenDataBase();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "XoaThongTinPhieuNhaps";
                sqlCommand.Parameters.Add("@MaPhieuNhap", SqlDbType.Char).Value = MaPhieuNhap;
                sqlCommand.Connection = sqlConnection;
                int k = sqlCommand.ExecuteNonQuery();
                return k > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PhieuNhap> HienThiToanBoDanhSachPhieuNhap()
        {
            try
            {
                List<PhieuNhap> DanhSach = new List<PhieuNhap>();
                OpenDataBase();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "HienThiToanBoDanhSachPhieuNhap";
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    DanhSach.Add(new PhieuNhap
                    {
                        MaPhieuNhap = sqlDataReader[0].ToString(),
                        NhanVien = sqlDataReader[1].ToString(),
                        NhaCungCap = sqlDataReader[2].ToString(),
                        NgayNhap = DateTime.Parse(sqlDataReader[3].ToString())
                    });
                }
                sqlDataReader.Close();
                return DanhSach;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PhieuNhap> HienThiDanhSachPhieuNhapTheoNhaCungCap(string MaKhoHang)
        {
            try
            {
                List<PhieuNhap> DanhSach = new List<PhieuNhap>();
                OpenDataBase();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "LayDanhSachHoaDonTheoNhaCungCap";
                sqlCommand.Parameters.Add("@MaNhaCungCap", SqlDbType.Char).Value = MaKhoHang;
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    DanhSach.Add(new PhieuNhap
                    {
                        MaPhieuNhap = sqlDataReader[0].ToString(),
                        NhanVien = sqlDataReader[1].ToString(),
                        NhaCungCap = sqlDataReader[2].ToString(),
                        NgayNhap = DateTime.Parse(sqlDataReader[3].ToString())
                    });
                }
                sqlDataReader.Close();
                return DanhSach;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PhieuNhap> HienThiDanhSachPhieuNhapTheoNhanVien(string MaNhanVien)
        {
            try
            {
                List<PhieuNhap> DanhSach = new List<PhieuNhap>();
                OpenDataBase();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "LayDanhSachHoaDonTheoNhanVien";
                sqlCommand.Parameters.Add("@MaNhanVien", SqlDbType.Char).Value = MaNhanVien;
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    DanhSach.Add(new PhieuNhap
                    {
                        MaPhieuNhap = sqlDataReader[0].ToString(),
                        NhanVien = sqlDataReader[1].ToString(),
                        NhaCungCap = sqlDataReader[2].ToString(),
                        NgayNhap = DateTime.Parse(sqlDataReader[3].ToString())
                    });
                }
                sqlDataReader.Close();
                return DanhSach;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        

        //public int ThemMoiPhieuNhap(PhieuNhap phieuNhap)
        //{
        //    try
        //    {
                
               
        //        OpenDataBase();
        //        SqlCommand sqlCommand = new SqlCommand();
        //        sqlCommand.CommandType = CommandType.StoredProcedure;
        //        sqlCommand.CommandText = "ThemMoiHoaDonNhap";
        //        sqlCommand.Parameters.Add("@MaPhieuNhap", SqlDbType.Char).Value = phieuNhap.MaPhieuNhap;
        //        sqlCommand.Parameters.Add("@MaNhanVien", SqlDbType.Char).Value = phieuNhap.MaNhanVien;
        //        sqlCommand.Parameters.Add("@MaNhaCungCap", SqlDbType.Char).Value = phieuNhap.MaNhaCungCap;
        //        sqlCommand.Parameters.Add("@NgayNhap", SqlDbType.DateTime).Value = phieuNhap.NgayNhap;
        //        sqlCommand.Connection = sqlConnection;
        //        int k = sqlCommand.ExecuteNonQuery();
        //        return k > 0;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
